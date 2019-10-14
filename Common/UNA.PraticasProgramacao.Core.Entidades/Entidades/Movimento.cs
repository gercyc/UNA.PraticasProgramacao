namespace UNA.PraticasProgramacao.Core.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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


        public virtual ICollection<ItemMovimento> ItemMovimento { get; set; }

        [ForeignKey("IdFormaPagamento")]
        public virtual FormaPagamento FormaPagamento { get; set; }

        [ForeignKey("IdParceiro")]
        public virtual Parceiro Parceiro { get; set; }

        [ForeignKey("IdTipoMovimento")]
        public virtual TipoMovimento TipoMovimento { get; set; }
    }
}
