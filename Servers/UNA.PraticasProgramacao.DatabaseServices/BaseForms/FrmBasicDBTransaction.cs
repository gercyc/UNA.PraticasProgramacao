using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNA.PraticasProgramacao.DatabaseServices.BaseClasses;

namespace UNA.PraticasProgramacao.DatabaseServices.BaseForms
{
    public partial class FrmBasicDBTransaction : Form
    {
        public ActionForm Action;
        public FrmBasicDBTransaction()
        {
            InitializeComponent();
            Action = ActionForm.Creating;
        }
        protected virtual bool IsValid()
        {
            return true;
        }
    }
}
