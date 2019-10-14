namespace UNA.PraticasProgramacao.Core.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CentroCusto")]
    public partial class CentroCusto
    {
        public CentroCusto()
        {
        }

        [Key]
        public int IdCentroCusto { get; set; }

        [Required]
        [StringLength(80)]
        public string NomeCentroCusto { get; set; }

        [StringLength(80)]
        public string Responsavel { get; set; }

    }
}
