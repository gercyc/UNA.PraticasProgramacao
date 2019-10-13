namespace UNA.PraticasProgramacao.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LancamentoFinanceiro")]
    public partial class LancamentoFinanceiro
    {
        [Key]
        public int IdLancamentoFinanceiro { get; set; }

        [StringLength(20)]
        public string NumeroLancamento { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataVencimento { get; set; }

        public int? IdCentroCusto { get; set; }

        public int? TipoLancamento { get; set; }

        [StringLength(100)]
        public string HistoricoLancamento { get; set; }

        public decimal? ValorLancamento { get; set; }

        public int? IdContaBancaria { get; set; }

        public DateTime? DataPagamento { get; set; }

        public int? IdParceiro { get; set; }

        public virtual CentroCusto CentroCusto { get; set; }

        public virtual ContaBancaria ContaBancaria { get; set; }

        public virtual Parceiro Parceiro { get; set; }
    }
}
