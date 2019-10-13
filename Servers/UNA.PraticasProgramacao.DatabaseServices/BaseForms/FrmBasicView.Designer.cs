namespace UNA.PraticasProgramacao.DatabaseServices.BaseForms
{
    partial class FrmBasicView<T>
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
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btnNovo = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.barStatus = new System.Windows.Forms.StatusStrip();
            this.lbMensagem = new System.Windows.Forms.ToolStripStatusLabel();
            this.DefaultGridView = new System.Windows.Forms.DataGridView();
            this.tsMenu.SuspendLayout();
            this.barStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNovo,
            this.btnEdit,
            this.btnDelete,
            this.btnRefresh});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(800, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "toolStrip1";
            // 
            // btnNovo
            // 
            this.btnNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNovo.Image = global::UNA.PraticasProgramacao.DatabaseServices.Properties.Resources.page_white;
            this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(23, 22);
            this.btnNovo.Text = "Novo Registro";
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = global::UNA.PraticasProgramacao.DatabaseServices.Properties.Resources.page_edit;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(23, 22);
            this.btnEdit.Text = "Editar Registro";
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::UNA.PraticasProgramacao.DatabaseServices.Properties.Resources.page_delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 22);
            this.btnDelete.Text = "Remover Registro";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::UNA.PraticasProgramacao.DatabaseServices.Properties.Resources.arrow_refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "toolStripButton1";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // barStatus
            // 
            this.barStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbMensagem});
            this.barStatus.Location = new System.Drawing.Point(0, 428);
            this.barStatus.Name = "barStatus";
            this.barStatus.Size = new System.Drawing.Size(800, 22);
            this.barStatus.TabIndex = 1;
            this.barStatus.Text = "statusStrip1";
            // 
            // lbMensagem
            // 
            this.lbMensagem.Name = "lbMensagem";
            this.lbMensagem.Size = new System.Drawing.Size(66, 17);
            this.lbMensagem.Text = "Mensagem";
            // 
            // DefaultGridView
            // 
            this.DefaultGridView.AllowUserToAddRows = false;
            this.DefaultGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DefaultGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DefaultGridView.Location = new System.Drawing.Point(0, 25);
            this.DefaultGridView.Name = "DefaultGridView";
            this.DefaultGridView.Size = new System.Drawing.Size(800, 403);
            this.DefaultGridView.TabIndex = 2;
            this.DefaultGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DefaultGridView_CellDoubleClick);
            // 
            // FrmBasicView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DefaultGridView);
            this.Controls.Add(this.barStatus);
            this.Controls.Add(this.tsMenu);
            this.Name = "FrmBasicView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBasicView";
            this.Load += new System.EventHandler(this.FrmBasicView_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.barStatus.ResumeLayout(false);
            this.barStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.ToolStripButton btnNovo;
        protected System.Windows.Forms.ToolStripButton btnEdit;
        protected System.Windows.Forms.ToolStripButton btnDelete;
        protected System.Windows.Forms.ToolStrip tsMenu;
        public System.Windows.Forms.ToolStripStatusLabel lbMensagem;
        protected System.Windows.Forms.DataGridView DefaultGridView;
        protected System.Windows.Forms.StatusStrip barStatus;
        private System.Windows.Forms.ToolStripButton btnRefresh;
    }
}