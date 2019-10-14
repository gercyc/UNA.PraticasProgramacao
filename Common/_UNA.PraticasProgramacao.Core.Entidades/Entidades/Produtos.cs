namespace UNA.PraticasProgramacao.Core.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Produtos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produtos()
        {
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

        [ForeignKey("IdCategoria")]
        public virtual CategoriaProduto CategoriaProduto { get; set; }

        [ForeignKey("IdUnidadeMedida")]
        public virtual UnidadeMedida UnidadeMedida { get; set; }
    }
}
