namespace ConfigBalanceadorAlternativo
{
    partial class Configurador
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.CaminhoArquivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Buscar = new System.Windows.Forms.Button();
            this.CriarConfiguracao = new System.Windows.Forms.Button();
            this.ChaveBalanceador = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GuidServidorSecundario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AliasServidorSecundario = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CaminhoArquivo
            // 
            this.CaminhoArquivo.Location = new System.Drawing.Point(12, 25);
            this.CaminhoArquivo.Name = "CaminhoArquivo";
            this.CaminhoArquivo.Size = new System.Drawing.Size(512, 20);
            this.CaminhoArquivo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Caminho do seu servidor principal";
            // 
            // Buscar
            // 
            this.Buscar.Location = new System.Drawing.Point(530, 23);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(75, 23);
            this.Buscar.TabIndex = 2;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // CriarConfiguracao
            // 
            this.CriarConfiguracao.Location = new System.Drawing.Point(364, 140);
            this.CriarConfiguracao.Name = "CriarConfiguracao";
            this.CriarConfiguracao.Size = new System.Drawing.Size(241, 23);
            this.CriarConfiguracao.TabIndex = 3;
            this.CriarConfiguracao.Text = "Criar uma cópia com os arquivos necessários";
            this.CriarConfiguracao.UseVisualStyleBackColor = true;
            this.CriarConfiguracao.Click += new System.EventHandler(this.CriarConfiguracao_Click);
            // 
            // ChaveBalanceador
            // 
            this.ChaveBalanceador.Location = new System.Drawing.Point(12, 64);
            this.ChaveBalanceador.Name = "ChaveBalanceador";
            this.ChaveBalanceador.Size = new System.Drawing.Size(512, 20);
            this.ChaveBalanceador.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(354, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Chave do balanceador alternativo (aquela chave que expira em 24 horas)";
            // 
            // GuidServidorSecundario
            // 
            this.GuidServidorSecundario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.GuidServidorSecundario.FormattingEnabled = true;
            this.GuidServidorSecundario.Items.AddRange(new object[] {
            "{FF1A0457-A074-4898-BBD9-10C6008E9762}",
            "{979B2B49-5CEA-43DC-9E20-41B019528345}"});
            this.GuidServidorSecundario.Location = new System.Drawing.Point(12, 103);
            this.GuidServidorSecundario.Name = "GuidServidorSecundario";
            this.GuidServidorSecundario.Size = new System.Drawing.Size(512, 21);
            this.GuidServidorSecundario.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "GUID do servidor secundário";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Alias do servidor secundário";
            // 
            // AliasServidorSecundario
            // 
            this.AliasServidorSecundario.Location = new System.Drawing.Point(12, 143);
            this.AliasServidorSecundario.Name = "AliasServidorSecundario";
            this.AliasServidorSecundario.Size = new System.Drawing.Size(139, 20);
            this.AliasServidorSecundario.TabIndex = 10;
            // 
            // Configurador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 177);
            this.Controls.Add(this.AliasServidorSecundario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GuidServidorSecundario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChaveBalanceador);
            this.Controls.Add(this.CriarConfiguracao);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CaminhoArquivo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Configurador";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Balanceador Alternativo";
            this.Load += new System.EventHandler(this.Configurador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox CaminhoArquivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.Button CriarConfiguracao;
        private System.Windows.Forms.TextBox ChaveBalanceador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox GuidServidorSecundario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AliasServidorSecundario;
    }
}

