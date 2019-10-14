namespace UNA.PraticasProgramacao.Core.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FormaPagamento")]
    public partial class FormaPagamento
    {
        public FormaPagamento()
        {
        }

        [Key]
        public int IdFormaPagamento { get; set; }

        [StringLength(80)]
        public string DescricaoFormaPagamento { get; set; }

        public int? PrazoDias { get; set; }

    }
}
