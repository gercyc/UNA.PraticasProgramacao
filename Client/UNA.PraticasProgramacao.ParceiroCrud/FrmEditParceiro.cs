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
    public partial class FrmEditParceiro : FrmBasicDBTransaction
    {
        Parceiro _parceiro;
        public FrmEditParceiro()
        {
            InitializeComponent();
            btnEditar.Click += BtnEditar_Click;
            btnSalvar.Click += BtnSalvar_Click;
            _parceiro = new Parceiro();
            this.DefaultSource.DataSource = _parceiro;
        }
        public FrmEditParceiro(Parceiro parceiro) : this()
        {
            _parceiro = parceiro;
            Action = DatabaseServices.BaseClasses.ActionForm.Editing;
            this.DefaultSource.DataSource = parceiro;
            EnableComponents(false);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsValid())
            {
                MessageBox.Show("Preencha todos os campos!!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (FinanceiroContext ctx = new FinanceiroContext())
            {
                ctx.Entry<Parceiro>(_parceiro).State = Action == DatabaseServices.BaseClasses.ActionForm.Editing ? System.Data.Entity.EntityState.Modified : System.Data.Entity.EntityState.Added;
                var result = ctx.SaveChanges();
                if (result == 1)
                {
                    string msg = $"Parceiro {(Action == DatabaseServices.BaseClasses.ActionForm.Editing ? "alterado" : "criado")} com sucesso!!";
                    MessageBox.Show(msg, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EnableComponents(true);
        }


        private void EnableComponents(bool enabled)
        {
            txtBairro.Enabled = enabled;
            txtCnpfCpf.Enabled = enabled;
            txtComplemento.Enabled = enabled;
            txtEndereco.Enabled = enabled;
            txtMunicipio.Enabled = enabled;
            txtNome.Enabled = enabled;
            txtNumEndereco.Enabled = enabled;
            txtUf.Enabled = enabled;
            cbTipoParceiro.Enabled = enabled;
            btnSalvar.Enabled = enabled;
        }
        protected override bool IsValid()
        {
            return _parceiro != null
                && _parceiro.Bairro != null
                && _parceiro.Complemento != null
                && _parceiro.CpfCnpj != null
                && _parceiro.Estado != null
                && _parceiro.Municipio != null
                && _parceiro.NomeEndereco != null
                && _parceiro.NomeParceiro != null
                && _parceiro.NumeroEndereco != null
                && _parceiro.TipoParceiro > 0;
        }
    }
}
