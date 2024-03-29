namespace UNA.PraticasProgramacao.Core.Entidades
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using UNA.PraticasProgramacao.Core.Entidades.Entidades;
    using UNA.PraticasProgramacao.Core.Entidades.Entidades.Identity;

    [Table("LancamentoFinanceiro")]
    public partial class LancamentoFinanceiro
    {
        [Key]
        public int IdLancamentoFinanceiro { get; set; }

        [StringLength(20)]
        public string NumeroLancamento { get; set; }

        [Display(Name = "Data de Cria��o"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCriacao { get; set; }

        [Display(Name = "Data de Vencimento"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "Centro de Custo")]
        public int? IdCentroCusto { get; set; }

        [Display(Name = "Tipo de Lan�amento")]
        public EnumTipoLancamento TipoLancamento { get; set; }

        [StringLength(100)]
        [Display(Name = "Hist�rico")]
        public string HistoricoLancamento { get; set; }

        [Display(Name = "Valor do lan�amento"), DisplayFormat(DataFormatString ="{0:N2}")]
        public decimal? ValorLancamento { get; set; }

        public int? IdContaBancaria { get; set; }

        [Display(Name = "Data de Pagamento"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataPagamento { get; set; }

        [Display(Name = "Parceiro")]
        public int? IdParceiro { get; set; }

        [ForeignKey("IdCentroCusto")]
        [Display(Name = "Centro de Custo")]
        public virtual CentroCusto CentroCusto { get; set; }

        [ForeignKey("IdContaBancaria")]
        [Display(Name = "Conta Banc�ria")] 
        public virtual ContaBancaria ContaBancaria { get; set; }

        [ForeignKey("IdParceiro")]
        [Display(Name = "Parceiro")]
        public virtual Parceiro Parceiro { get; set; }


        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser Usuario { get; set; }
    }
}
