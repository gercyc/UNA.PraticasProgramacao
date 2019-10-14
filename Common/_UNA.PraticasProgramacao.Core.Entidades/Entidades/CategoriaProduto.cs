namespace UNA.PraticasProgramacao.Core.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CategoriaProduto")]
    public partial class CategoriaProduto
    {
        public CategoriaProduto()
        {
        }

        [Key]
        public int IdCategoria { get; set; }

        [StringLength(6)]
        public string CodigoCategoria { get; set; }

        [StringLength(50)]
        public string DescricaoCategoria { get; set; }

    }
}
