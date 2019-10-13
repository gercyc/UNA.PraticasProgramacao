namespace UNA.PraticasProgramacao.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoriaProduto")]
    public partial class CategoriaProduto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategoriaProduto()
        {
            Produtos = new HashSet<Produtos>();
        }

        [Key]
        public int IdCategoria { get; set; }

        [StringLength(6)]
        public string CodigoCategoria { get; set; }

        [StringLength(50)]
        public string DescricaoCategoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produtos> Produtos { get; set; }
    }
}
