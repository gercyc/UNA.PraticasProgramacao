using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNA.PraticasProgramacao.ParceiroCrud;

namespace UNA.PraticasProgramacao.Desktop
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void parceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmParceiroView frmParceiroView = new FrmParceiroView();
            frmParceiroView.MdiParent = this;
            frmParceiroView.Show();
        }
    }
}