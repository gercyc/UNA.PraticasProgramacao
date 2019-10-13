namespace UNA.PraticasProgramacao.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UnidadeMedida")]
    public partial class UnidadeMedida
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UnidadeMedida()
        {
            Produtos = new HashSet<Produtos>();
        }

        [Key]
        public int IdUnidadeMedida { get; set; }

        [StringLength(6)]
        public string CodUnidadeMedida { get; set; }

        [StringLength(20)]
        public string NomeUnidadeMedida { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produtos> Produtos { get; set; }
    }
}
