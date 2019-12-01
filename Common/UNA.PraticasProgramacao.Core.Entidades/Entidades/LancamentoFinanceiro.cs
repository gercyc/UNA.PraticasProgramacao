/*
    UNA - Tecnologia em Analise e Desenvolvimento de sistemas
    Disciplina:Práticas de Programação
    Professor: Luiz Eduardo Carneiro
    Período: 2º semestre/2019
    Autores: Gercy Campos
    Informações: Entidade representação de uma Movimentação Financeira
*/
namespace UNA.PraticasProgramacao.Core.Entidades
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using UNA.PraticasProgramacao.Core.Entidades.Entidades;

    [Table("LancamentoFinanceiro")]//configura qual tabela esta classe está representando
    public partial class LancamentoFinanceiro
    {
        [Key]
        public int IdLancamentoFinanceiro { get; set; }

        [StringLength(20)]
        public string NumeroLancamento { get; set; }

        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; }

        [Display(Name = "Data de Vencimento")]
        [DataType(DataType.Date)]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "Centro de Custo")]
        public int? IdCentroCusto { get; set; }

        [Display(Name = "Tipo de Lançamento")]
        public EnumTipoLancamento TipoLancamento { get; set; }

        [StringLength(100)]
        [Display(Name = "Histórico")]
        public string HistoricoLancamento { get; set; }

        [Display(Name = "Valor do lançamento"), DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Currency)]
        public decimal ValorLancamento { get; set; }

        [Display(Name = "Valor do lançamento"), DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Currency)]
        [NotMapped]
        public string ValorLancamentoStr { get { return _valorLancamentoStr; } set { _valorLancamentoStr = value; } }
        string _valorLancamentoStr;

        [Display(Name = "Conta Bancária")]
        public int? IdContaBancaria { get; set; }

        [Display(Name = "Data de Pagamento"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DataPagamento { get; set; }

        [ForeignKey("IdCentroCusto")]
        [Display(Name = "Centro de Custo")]
        public virtual CentroCusto CentroCusto { get; set; }

        [ForeignKey("IdContaBancaria")]
        [Display(Name = "Conta Bancária")]
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
