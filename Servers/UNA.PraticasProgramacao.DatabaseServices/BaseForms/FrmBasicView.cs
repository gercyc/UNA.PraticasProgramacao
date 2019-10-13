using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNA.PraticasProgramacao.DatabaseServices.BaseInterfaces;

namespace UNA.PraticasProgramacao.DatabaseServices.BaseForms
{
    public partial class FrmBasicView<T> : Form, IGridViewForm
    {
        public FrmBasicView()
        {
            InitializeComponent();

        }

        public object Datasource
        {
            get
            {
                return ProtectedDatasource;
            }
        }

        protected virtual object ProtectedDatasource { get; }

        public event CelDoubleClick OnDataGridViewCellDoubleClick;
        public delegate void CelDoubleClick(object sender, DataGridViewCellEventArgs e);


        private void FrmBasicView_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        private void DefaultGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OnDataGridViewCellDoubleClick != null)
                OnDataGridViewCellDoubleClick(sender, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DefaultGridView.DataSource = Datasource;
        }
    }

}
