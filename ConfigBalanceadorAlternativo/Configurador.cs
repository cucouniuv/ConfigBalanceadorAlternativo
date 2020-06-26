using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigBalanceadorAlternativo
{
    public partial class Configurador : Form
    {
        public Configurador()
        {
            InitializeComponent();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog arquivo = new OpenFileDialog();
            arquivo.Title = "Escolha o arquivo referente ao executável do servidor";
            arquivo.Filter = "Executáveis de servidor (*servidor.exe)|*servidor.exe";

            if (arquivo.ShowDialog() == DialogResult.OK)
            {
                CaminhoArquivo.Text = arquivo.FileName;
            }
        }

        private void CriarConfiguracao_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutarValidacoes();
                CriarDiretorioSecundario();
                CopiarArquivosNoDiretorioSecundario();

                ModificarArquivoIniServidorSecundario();

                MessageBox.Show(
                    "Criado diretório 'ServidorSecundario' no mesmo diretório do executável selecionado.");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void ExecutarValidacoes()
        {
            if (CaminhoArquivo.Text.Trim().Length == 0)
            {
                throw new ArgumentException("Caminho do seu servidor principal precisa ser preenchido.");
            }

            string path = Path.GetDirectoryName(CaminhoArquivo.Text.Trim());

            if (!Directory.Exists(path))
            {
                throw new ArgumentException("Diretório inexistente.");
            }

            if (ChaveBalanceador.Text.Trim().Length == 0)
            {
                throw new ArgumentException("Chave do balanceador precisa ser preenchida.");
            }

            if (GuidServidorSecundario.Text.Trim().Length == 0)
            {
                throw new ArgumentException("GUID do servidor secundário precisa ser preenchido.");
            }

            if (AliasServidorSecundario.Text.Trim().Length == 0)
            {
                throw new ArgumentException("Alias do servidor secundário precisa ser preenchido.");
            }
        }

        private void CriarDiretorioSecundario()
        {
            string path = Path.GetDirectoryName(CaminhoArquivo.Text.Trim());

            string pathSecundario = Path.Combine(path, "ServidorSecundario");

            if (Directory.Exists(pathSecundario))
            {
                /*WatcherDiretorio.Path = path;
                WatcherDiretorio.NotifyFilter = NotifyFilters.DirectoryName;

                WatcherDiretorio.Deleted += (sender, evento) =>
                {
                    if (evento.FullPath == pathSecundario)
                    {
                        Directory.CreateDirectory(pathSecundario);
                    }
                };*/

                Directory.Delete(pathSecundario, true);
            }

            DirectoryInfo _directoryInfo = new DirectoryInfo(pathSecundario);
            _directoryInfo.Refresh();

            while (_directoryInfo.Exists)
                _directoryInfo.Refresh();

            Directory.CreateDirectory(pathSecundario);
        }

        private void CopiarArquivosNoDiretorioSecundario()
        {
            string pathOrigem = Path.GetDirectoryName(CaminhoArquivo.Text.Trim());
            
            string pathDestino = Path.Combine(pathOrigem, "ServidorSecundario");

            if (!Directory.Exists(pathDestino))
            {
                throw new ArgumentException("Diretório secundário inexistente.");
            }

            string nomeArquivo = Path.GetFileNameWithoutExtension(CaminhoArquivo.Text.Trim()) + "01.exe";
            
            File.Copy(CaminhoArquivo.Text.Trim(), Path.Combine(pathDestino, nomeArquivo));
            
            var listaDLL = Directory.EnumerateFiles(pathOrigem, ("*.dll"), SearchOption.TopDirectoryOnly);

            if (listaDLL.Count() == 0)
            {
                throw new ArgumentException("Arquivos DLL não encontrados.");
            }

            foreach (string dll in listaDLL)
            {
                File.Copy(dll, Path.Combine(pathDestino, Path.GetFileName(dll)));
            }

            if (File.Exists(Path.Combine(pathOrigem, "spCfg.ini")))
            {
                File.Copy(Path.Combine(pathOrigem, "spCfg.ini"), Path.Combine(pathDestino, "spCfg.ini"));
            }

            if (File.Exists(Path.Combine(pathOrigem, "ProcessadorPDF.exe")))
            {
                File.Copy(Path.Combine(pathOrigem, "ProcessadorPDF.exe"), 
                    Path.Combine(pathDestino, "ProcessadorPDF.exe"));
            }
        }

        private void ModificarArquivoIniServidorSecundario()
        {
            string pathOrigem = Path.GetDirectoryName(CaminhoArquivo.Text.Trim());
            string pathDestino = Path.Combine(pathOrigem, "ServidorSecundario");

            string pathIniDestino = Path.Combine(pathDestino, "spCfg.ini");

            if (!File.Exists(pathIniDestino))
            {
                throw new ArgumentException("Arquivo spCfg.ini não encontrado no diretório ServidorSecundario");
            }

            ArquivoIni iniDestino = new ArquivoIni(pathIniDestino);

            string nomeArquivoOrigem = Path.GetFileName(CaminhoArquivo.Text.Trim());
            string nomeArquivoDestino = Path.GetFileNameWithoutExtension(CaminhoArquivo.Text.Trim()) + "01.exe";

            string enderecoIPOrigem = iniDestino.LerDoIni("Servidor", "EnderecoIP");

            string nomeServidorOrigem = iniDestino.LerDoIni("Servidor", "nomeServidor");
            string nomeServidorDestino = nomeServidorOrigem + "01";

            string guidOrigem = iniDestino.LerDoIni("Servidor", "GUIDServidor");
            string guidDestino = GuidServidorSecundario.Text.Trim();

            string aliasOrigem = iniDestino.LerDoIni("Database", "Alias");
            string aliasDestino = AliasServidorSecundario.Text.Trim();

            iniDestino.EscreverNoIni("Servidor", "nomeServidor", nomeServidorDestino);
            iniDestino.EscreverNoIni("Servidor", "GUIDServidor", guidDestino);
            iniDestino.EscreverNoIni("Database", "Alias", aliasDestino);

            iniDestino.EscreverNoIni("BalanceadorAlternativo", "Chave", ChaveBalanceador.Text.Trim());

            string valorBalanceador;

            valorBalanceador = String.Format("{0};{1};{2};{3};", 
                nomeServidorOrigem, nomeArquivoOrigem, guidOrigem, enderecoIPOrigem);
            iniDestino.EscreverNoIni("BalanceadorAlternativo", aliasOrigem, valorBalanceador);

            valorBalanceador = String.Format("{0};{1};{2};{3};",
                nomeServidorDestino, nomeArquivoDestino, guidDestino, enderecoIPOrigem);
            iniDestino.EscreverNoIni("BalanceadorAlternativo", aliasDestino, valorBalanceador);

            // spCfg.ini de origem
            ArquivoIni iniOrigem = new ArquivoIni(Path.Combine(pathOrigem, "spCfg.ini"));

            iniOrigem.EscreverNoIni("BalanceadorAlternativo", "Chave", ChaveBalanceador.Text.Trim());

            valorBalanceador = String.Format("{0};{1};{2};{3};",
                nomeServidorOrigem, nomeArquivoOrigem, guidOrigem, enderecoIPOrigem);
            iniOrigem.EscreverNoIni("BalanceadorAlternativo", aliasOrigem, valorBalanceador);

            valorBalanceador = String.Format("{0};{1};{2};{3};",
                nomeServidorDestino, nomeArquivoDestino, guidDestino, enderecoIPOrigem);
            iniOrigem.EscreverNoIni("BalanceadorAlternativo", aliasDestino, valorBalanceador);
        }

        private void Configurador_Load(object sender, EventArgs e)
        {
            GuidServidorSecundario.SelectedIndex = 0;
        }

        private void AbrirServidorSecundario_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirServidorSecundarioEvent();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }            
        }

        private void AbrirServidorSecundarioEvent()
        {
            if (CaminhoArquivo.Text.Trim().Length == 0)
            {
                throw new ArgumentException("Caminho do seu servidor principal precisa ser preenchido.");
            }

            string pathOrigem = Path.GetDirectoryName(CaminhoArquivo.Text.Trim());

            string nomeArquivoDestino = Path.GetFileNameWithoutExtension(CaminhoArquivo.Text.Trim()) + "01.exe";

            string pathDestino = Path.Combine(pathOrigem, "ServidorSecundario", nomeArquivoDestino);

            if (!File.Exists(pathDestino))
            {
                throw new ArgumentException(String.Format("Arquivo {0} não encontrado.", nomeArquivoDestino));
            }

            System.Diagnostics.Process.Start(pathDestino);
        }

        private void AbrirConfiguracaoSecundario_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirConfiguracaoSecundarioEvent();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void AbrirConfiguracaoSecundarioEvent()
        {
            if (CaminhoArquivo.Text.Trim().Length == 0)
            {
                throw new ArgumentException("Caminho do seu servidor principal precisa ser preenchido.");
            }

            string pathOrigem = Path.GetDirectoryName(CaminhoArquivo.Text.Trim());

            string pathDestino = Path.Combine(pathOrigem, "ServidorSecundario", "spCfg.ini");

            if (!File.Exists(pathDestino))
            {
                throw new ArgumentException("Arquivo spCfg.ini não encontrado no diretório secundário.");
            }

            System.Diagnostics.Process.Start(pathDestino);
        }

        private void EnderecoGit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/cucouniuv/ConfigBalanceadorAlternativo");
        }
    }
}
