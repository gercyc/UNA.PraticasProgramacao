namespace UNA.PraticasProgramacao.ParceiroCrud
{
    partial class FrmEditParceiro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCnpfCpf = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumEndereco = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUf = new System.Windows.Forms.TextBox();
            this.cbTipoParceiro = new System.Windows.Forms.ComboBox();
            this.parceiroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parceiroBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbTipoParceiro);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtUf);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtMunicipio);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtBairro);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtComplemento);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtNumEndereco);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtEndereco);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCnpfCpf);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Size = new System.Drawing.Size(470, 208);
            // 
            // DefaultSource
            // 
            this.DefaultSource.DataSource = typeof(UNA.PraticasProgramacao.Entidades.Parceiro);
            // 
            // txtNome
            // 
            this.txtNome.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DefaultSource, "NomeParceiro", true));
            this.txtNome.Location = new System.Drawing.Point(15, 31);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(193, 20);
            this.txtNome.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome Parceiro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo Parceiro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "CPF/CNPJ";
            // 
            // txtCnpfCpf
            // 
            this.txtCnpfCpf.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DefaultSource, "CpfCnpj", true));
            this.txtCnpfCpf.Location = new System.Drawing.Point(15, 121);
            this.txtCnpfCpf.Name = "txtCnpfCpf";
            this.txtCnpfCpf.Size = new System.Drawing.Size(193, 20);
            this.txtCnpfCpf.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Endereço";
            // 
            // txtEndereco
            // 
            this.txtEndereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DefaultSource, "NomeEndereco", true));
            this.txtEndereco.Location = new System.Drawing.Point(227, 31);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(193, 20);
            this.txtEndereco.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Número Endereço";
            // 
            // txtNumEndereco
            // 
            this.txtNumEndereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DefaultSource, "NumeroEndereco", true));
            this.txtNumEndereco.Location = new System.Drawing.Point(227, 75);
            this.txtNumEndereco.Name = "txtNumEndereco";
            this.txtNumEndereco.Size = new System.Drawing.Size(193, 20);
            this.txtNumEndereco.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Complemento Endereço";
            // 
            // txtComplemento
            // 
            this.txtComplemento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DefaultSource, "Complemento", true));
            this.txtComplemento.Location = new System.Drawing.Point(227, 121);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(193, 20);
            this.txtComplemento.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Bairro";
            // 
            // txtBairro
            // 
            this.txtBairro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DefaultSource, "Bairro", true));
            this.txtBairro.Location = new System.Drawing.Point(15, 166);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(94, 20);
            this.txtBairro.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(256, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Município";
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DefaultSource, "Municipio", true));
            this.txtMunicipio.Location = new System.Drawing.Point(259, 166);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(94, 20);
            this.txtMunicipio.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(356, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "UF";
            // 
            // txtUf
            // 
            this.txtUf.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DefaultSource, "Estado", true));
            this.txtUf.Location = new System.Drawing.Point(359, 166);
            this.txtUf.Name = "txtUf";
            this.txtUf.Size = new System.Drawing.Size(62, 20);
            this.txtUf.TabIndex = 8;
            // 
            // cbTipoParceiro
            // 
            this.cbTipoParceiro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DefaultSource, "TipoParceiro", true));
            this.cbTipoParceiro.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.DefaultSource, "TipoParceiro", true));
            this.cbTipoParceiro.FormattingEnabled = true;
            this.cbTipoParceiro.Items.AddRange(new object[] {
            "",
            "Ambos",
            "Cliente",
            "Fornecedor"});
            this.cbTipoParceiro.Location = new System.Drawing.Point(15, 75);
            this.cbTipoParceiro.Name = "cbTipoParceiro";
            this.cbTipoParceiro.Size = new System.Drawing.Size(193, 21);
            this.cbTipoParceiro.TabIndex = 1;
            // 
            // parceiroBindingSource
            // 
            this.parceiroBindingSource.DataSource = typeof(UNA.PraticasProgramacao.Entidades.Parceiro);
            // 
            // FrmEditParceiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 255);
            this.Name = "FrmEditParceiro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEditParceiro";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parceiroBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUf;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumEndereco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCnpfCpf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTipoParceiro;
        private System.Windows.Forms.BindingSource parceiroBindingSource;
    }
}