/*
    UNA - Tecnologia em Analise e Desenvolvimento de sistemas
    Disciplina:Práticas de Programação
    Professor: Luiz Eduardo Carneiro
    Período: 2º semestre/2019
    Autores: Gercy Campos
    Informações: Entidade Centro de Custo
*/
namespace UNA.PraticasProgramacao.Core.Entidades
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CentroCusto")]
    public partial class CentroCusto
    {
        public CentroCusto()
        {
        }

        [Key]
        public int IdCentroCusto { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name ="Nome do Centro")]
        public string NomeCentroCusto { get; set; }

        [StringLength(80)]
        [Display(Name = "Responsável")]
        public string Responsavel { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser Usuario { get; set; }
    }
}
