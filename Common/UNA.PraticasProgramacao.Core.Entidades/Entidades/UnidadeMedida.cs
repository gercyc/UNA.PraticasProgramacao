namespace UNA.PraticasProgramacao.Core.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UnidadeMedida")]
    public partial class UnidadeMedida
    {
        public UnidadeMedida()
        {
        }

        [Key]
        public int IdUnidadeMedida { get; set; }

        [StringLength(6)]
        public string CodUnidadeMedida { get; set; }

        [StringLength(20)]
        public string NomeUnidadeMedida { get; set; }

    }
}
