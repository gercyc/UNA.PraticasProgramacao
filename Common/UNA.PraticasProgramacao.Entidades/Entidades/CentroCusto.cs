namespace UNA.PraticasProgramacao.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CentroCusto")]
    public partial class CentroCusto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CentroCusto()
        {
            LancamentoFinanceiro = new HashSet<LancamentoFinanceiro>();
        }

        [Key]
        public int IdCentroCusto { get; set; }

        [Required]
        [StringLength(80)]
        public string NomeCentroCusto { get; set; }

        [StringLength(80)]
        public string Responsavel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LancamentoFinanceiro> LancamentoFinanceiro { get; set; }
    }
}
