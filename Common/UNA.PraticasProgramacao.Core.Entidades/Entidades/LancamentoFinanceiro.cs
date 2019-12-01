/*
    UNA - Tecnologia em Analise e Desenvolvimento de sistemas
    Disciplina:Pr�ticas de Programa��o
    Professor: Luiz Eduardo Carneiro
    Per�odo: 2� semestre/2019
    Autores: Gercy Campos
    Informa��es: Entidade representa��o de uma Movimenta��o Financeira
*/
namespace UNA.PraticasProgramacao.Core.Entidades
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using UNA.PraticasProgramacao.Core.Entidades.Entidades;

    [Table("LancamentoFinanceiro")]//configura qual tabela esta classe est� representando
    public partial class LancamentoFinanceiro
    {
        [Key]
        public int IdLancamentoFinanceiro { get; set; }

        [StringLength(20)]
        public string NumeroLancamento { get; set; }

        [Display(Name = "Data de Cria��o")]
        public DateTime DataCriacao { get; set; }

        [Display(Name = "Data de Vencimento")]
        [DataType(DataType.Date)]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "Centro de Custo")]
        public int? IdCentroCusto { get; set; }

        [Display(Name = "Tipo de Lan�amento")]
        public EnumTipoLancamento TipoLancamento { get; set; }

        [StringLength(100)]
        [Display(Name = "Hist�rico")]
        public string HistoricoLancamento { get; set; }

        [Display(Name = "Valor do lan�amento"), DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Currency)]
        public decimal ValorLancamento { get; set; }

        [Display(Name = "Valor do lan�amento"), DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Currency)]
        [NotMapped]
        public string ValorLancamentoStr { get { return _valorLancamentoStr; } set { _valorLancamentoStr = value; } }
        string _valorLancamentoStr;

        [Display(Name = "Conta Banc�ria")]
        public int? IdContaBancaria { get; set; }

        [Display(Name = "Data de Pagamento"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DataPagamento { get; set; }

        [ForeignKey("IdCentroCusto")]
        [Display(Name = "Centro de Custo")]
        public virtual CentroCusto CentroCusto { get; set; }

        [ForeignKey("IdContaBancaria")]
        [Display(Name = "Conta Banc�ria")]
        public virtual ContaBancaria ContaBancaria { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser Usuario { get; set; }
        public LancamentoFinanceiro()
        {
            _valorLancamentoStr = ValorLancamento.ToString("N2");
        }
    }
}
