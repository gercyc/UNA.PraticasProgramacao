namespace UNA.PraticasProgramacao.Core.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoMovimento")]
    public partial class TipoMovimento
    {
        public TipoMovimento()
        {
        }

        [Key]
        public int IdTipoMovimento { get; set; }

        [StringLength(50)]
        public string NomeTipoMovimento { get; set; }

        [StringLength(100)]
        public string Observacoes { get; set; }

    }
}
