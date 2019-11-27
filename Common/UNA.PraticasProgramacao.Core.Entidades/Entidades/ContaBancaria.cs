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
        public string Agencia { get; set; }

        [Required]
        [StringLength(20)]
        public string NumeroConta { get; set; }

        public decimal? SaldoInicial { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser Usuario { get; set; }

    }
}
