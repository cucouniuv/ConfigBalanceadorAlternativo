using System.Runtime.InteropServices;
using System.Text;

namespace ConfigBalanceadorAlternativo
{
    class ArquivoIni
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal, int size, string filePath);

        public void EscreverNoIni(string secao, string chave, string valor)
        {
            WritePrivateProfileString(secao, chave, valor, _caminhoArquivo);
        }

        public string LerDoIni(string secao, string chave)
        {
            StringBuilder temp = new StringBuilder(255);
            _ = GetPrivateProfileString(secao, chave, "", temp, 255, _caminhoArquivo);
            return temp.ToString();
        }

        private readonly string _caminhoArquivo;

        public ArquivoIni(string caminhoArquivo)
        {
            _caminhoArquivo = caminhoArquivo;
        }
    }
}
