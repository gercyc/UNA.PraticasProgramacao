namespace UNA.PraticasProgramacao.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Movimento")]
    public partial class Movimento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movimento()
        {
            ItemMovimento = new HashSet<ItemMovimento>();
        }

        [Key]
        public int IdMovimento { get; set; }

        public int? IdTipoMovimento { get; set; }

        public DateTime? DataMovimento { get; set; }

        public int? IdParceiro { get; set; }

        [StringLength(80)]
        public string Observacao { get; set; }

        public decimal? ValorDesconto { get; set; }

        public decimal? ValorTotal { get; set; }

        public int? IdFormaPagamento { get; set; }

        public virtual FormaPagamento FormaPagamento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemMovimento> ItemMovimento { get; set; }

        public virtual Parceiro Parceiro { get; set; }

        public virtual TipoMovimento TipoMovimento { get; set; }
    }
}
