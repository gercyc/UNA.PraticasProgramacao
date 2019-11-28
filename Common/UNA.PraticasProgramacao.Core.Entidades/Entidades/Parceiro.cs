namespace UNA.PraticasProgramacao.Core.Entidades
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Parceiro")]
    public partial class Parceiro
    {
        public Parceiro()
        {
  
        }

        [Key]
        public int IdParceiro { get; set; }

        [StringLength(100)]
        [Display(Name = "Nome")]
        public string NomeParceiro { get; set; }

        [Display(Name = "Tipo de Parceiro")]
        public EnumTipoParceiro TipoParceiro { get; set; }

        [StringLength(14)]
        [Display(Name = "CPF/CNPJ")]
        public string CpfCnpj { get; set; }

        [StringLength(100)]
        [Display(Name = "Endereço")]
        public string NomeEndereco { get; set; }

        [StringLength(10)]
        [Display(Name = "Número")]
        public string NumeroEndereco { get; set; }

        [StringLength(20)]
        public string Complemento { get; set; }

        [StringLength(50)]
        public string Bairro { get; set; }

        [StringLength(80)]
        [Display(Name = "Município")]
        public string Municipio { get; set; }

        [StringLength(2)]
        public string Estado { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser Usuario { get; set; }
    }
}
