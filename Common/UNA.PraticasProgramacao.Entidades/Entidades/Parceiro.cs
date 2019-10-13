namespace UNA.PraticasProgramacao.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using UNA.PraticasProgramacao.Entidades.Entidades;

    [Table("Parceiro")]
    public partial class Parceiro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Parceiro()
        {
  
        }

        [Key]
        public int IdParceiro { get; set; }

        [StringLength(100)]
        public string NomeParceiro { get; set; }

        public EnumTipoParceiro TipoParceiro { get; set; }

        [StringLength(14)]
        public string CpfCnpj { get; set; }

        [StringLength(100)]
        public string NomeEndereco { get; set; }

        [StringLength(10)]
        public string NumeroEndereco { get; set; }

        [StringLength(20)]
        public string Complemento { get; set; }

        [StringLength(50)]
        public string Bairro { get; set; }

        [StringLength(80)]
        public string Municipio { get; set; }

        [StringLength(2)]
        public string Estado { get; set; }
    }
}
