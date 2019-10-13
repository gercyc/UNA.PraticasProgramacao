namespace UNA.PraticasProgramacao.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Produtos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produtos()
        {
            ItemMovimento = new HashSet<ItemMovimento>();
        }

        [Key]
        public int IdProduto { get; set; }

        [StringLength(10)]
        public string CodigoProduto { get; set; }

        [StringLength(200)]
        public string DescricaoProduto { get; set; }

        [StringLength(8)]
        public string Ncm { get; set; }

        public int? IdUnidadeMedida { get; set; }

        public int? IdCategoria { get; set; }

        public virtual CategoriaProduto CategoriaProduto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemMovimento> ItemMovimento { get; set; }

        public virtual UnidadeMedida UnidadeMedida { get; set; }
    }
}
