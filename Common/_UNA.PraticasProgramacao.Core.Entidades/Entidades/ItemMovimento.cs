namespace UNA.PraticasProgramacao.Core.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ItemMovimento")]
    public partial class ItemMovimento
    {
        [Key]
        public int IdItemMovimento { get; set; }

        public int IdMovimento { get; set; }

        public int? IdProduto { get; set; }

        public decimal? Quantidade { get; set; }

        public decimal? ValorUnitario { get; set; }

        public decimal? ValorTotal { get; set; }

        public decimal? ValorDesconto { get; set; }

        [ForeignKey("IdMovimento")]
        public virtual Movimento Movimento { get; set; }

        [ForeignKey("IdProduto")]
        public virtual Produtos Produtos { get; set; }
    }
}
