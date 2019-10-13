namespace UNA.PraticasProgramacao.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContaBancaria")]
    public partial class ContaBancaria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContaBancaria()
        {
            LancamentoFinanceiro = new HashSet<LancamentoFinanceiro>();
        }

        [Key]
        public int IdContaBancaria { get; set; }

        [Required]
        [StringLength(15)]
        public string Banco { get; set; }

        [Required]
        [StringLength(6)]
        public string Agencia { get; set; }

        [Required]
        [StringLength(20)]
        public string NumeroConta { get; set; }

        public decimal? SaldoInicial { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LancamentoFinanceiro> LancamentoFinanceiro { get; set; }
    }
}
