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

        [Display(Name = "Data de Criação"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCriacao { get; set; }

        [Display(Name = "Data de Vencimento"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataVencimento { get; set; }

        public int? IdCentroCusto { get; set; }

        public EnumTipoLancamento TipoLancamento { get; set; }

        [StringLength(100)]
        public string HistoricoLancamento { get; set; }

        [Display(Name = "Valor do lançamento"), DisplayFormat(DataFormatString ="{0:N2}")]
        public decimal? ValorLancamento { get; set; }

        public int? IdContaBancaria { get; set; }

        [Display(Name = "Data de Pagamento"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataPagamento { get; set; }

        public int? IdParceiro { get; set; }


        [ForeignKey("IdCentroCusto")]
        public virtual CentroCusto CentroCusto { get; set; }

        [ForeignKey("IdContaBancaria")]
        public virtual ContaBancaria ContaBancaria { get; set; }

        [ForeignKey("IdParceiro")]
        public virtual Parceiro Parceiro { get; set; }


        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser Usuario { get; set; }
    }
}
