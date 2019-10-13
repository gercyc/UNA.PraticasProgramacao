namespace UNA.PraticasProgramacao.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoMovimento")]
    public partial class TipoMovimento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoMovimento()
        {
            Movimento = new HashSet<Movimento>();
        }

        [Key]
        public int IdTipoMovimento { get; set; }

        [StringLength(50)]
        public string NomeTipoMovimento { get; set; }

        [StringLength(100)]
        public string Observacoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movimento> Movimento { get; set; }
    }
}
