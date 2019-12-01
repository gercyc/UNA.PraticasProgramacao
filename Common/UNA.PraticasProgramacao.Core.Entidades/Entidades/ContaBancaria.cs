/*
    UNA - Tecnologia em Analise e Desenvolvimento de sistemas
    Disciplina:Pr�ticas de Programa��o
    Professor: Luiz Eduardo Carneiro
    Per�odo: 2� semestre/2019
    Autores: Gercy Campos
    Informa��es: Entidade Conta Banc�ria
*/
namespace UNA.PraticasProgramacao.Core.Entidades
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ContaBancaria")]
    public partial class ContaBancaria
    {
        public ContaBancaria()
        {
        }

        [Key]
        public int IdContaBancaria { get; set; }

        [Required]
        [StringLength(15)]
        public string Banco { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Ag�ncia")]
        public string Agencia { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "N�mero da Conta")]
        public string NumeroConta { get; set; }

        [Display(Name = "Saldo Inicial")]
        public decimal? SaldoInicial { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser Usuario { get; set; }

        [NotMapped]
        public string NomeConta
        {
            get
            {
                return string.Format("{0} - AG: {1} - Conta: {2}", Banco, Agencia, NumeroConta);
            }
        }

    }
}
