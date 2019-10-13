using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNA.PraticasProgramacao.DatabaseServices.BaseForms;
using UNA.PraticasProgramacao.Entidades;

namespace UNA.PraticasProgramacao.ParceiroCrud
{
    public partial class FrmParceiroView : FrmBasicView<List<Parceiro>>
    {
        public FrmParceiroView()
        {
            InitializeComponent();
            this.OnDataGridViewCellDoubleClick += FrmParceiroView_OnDataGridViewCellDoubleClick;
            this.btnNovo.Click += BtnNovo_Click;
            this.btnEdit.Click += BtnEdit_Click;
            this.btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (DefaultGridView.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Selecione um item para remoção!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var s = DefaultGridView.SelectedRows;
            Parceiro current = ((BindingList<Parceiro>)DefaultGridView.DataSource)[s[0].Index] as Parceiro;

            var dr = MessageBox.Show("Certeza que deseja excluir o parceiro selecionado?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                using (var ctx = new FinanceiroContext())
                {
                    ctx.Entry<Parceiro>(current).State = System.Data.Entity.EntityState.Deleted;
                    if (ctx.SaveChanges() == 1)
                    {
                        DefaultGridView.Rows.Remove(DefaultGridView.SelectedRows[0]);
                        DefaultGridView.Refresh();
                        DefaultGridView.Update();
                    }
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (DefaultGridView.SelectedCells.Count <= 0)
                MessageBox.Show("Selecione um item para editar!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            var s = DefaultGridView.SelectedCells;
            Parceiro current = ((BindingList<Parceiro>)DefaultGridView.DataSource)[s[0].RowIndex] as Parceiro;
            FrmEditParceiro frmEditParceiro = new FrmEditParceiro(current);
            frmEditParceiro.Show();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            FrmEditParceiro frmEditParceiro = new FrmEditParceiro();
            frmEditParceiro.ShowDialog();
        }

        protected override object ProtectedDatasource
        {
            get
            {
                BindingList<Parceiro> parceiros;

                using (var ctx = new FinanceiroContext())
                {
                    parceiros = new BindingList<Parceiro>(ctx.Parceiro.ToList());
                }

                return parceiros;
            }
        }

        private void FrmParceiroView_OnDataGridViewCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnEdit_Click(null, null);
        }
    }

}
