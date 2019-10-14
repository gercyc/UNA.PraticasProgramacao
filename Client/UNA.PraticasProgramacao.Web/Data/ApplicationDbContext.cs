using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UNA.PraticasProgramacao.Core.Entidades;
using UNA.PraticasProgramacao.Core.Entidades.Entidades.Identity;

namespace UNA.PraticasProgramacao.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        public virtual DbSet<CategoriaProduto> CategoriaProduto { get; set; }
        public virtual DbSet<CentroCusto> CentroCusto { get; set; }
        public virtual DbSet<ContaBancaria> ContaBancaria { get; set; }
        public virtual DbSet<FormaPagamento> FormaPagamento { get; set; }
        public virtual DbSet<ItemMovimento> ItemMovimento { get; set; }
        public virtual DbSet<LancamentoFinanceiro> LancamentoFinanceiro { get; set; }
        public virtual DbSet<Movimento> Movimento { get; set; }
        public virtual DbSet<Parceiro> Parceiro { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
        public virtual DbSet<TipoMovimento> TipoMovimento { get; set; }
        public virtual DbSet<UnidadeMedida> UnidadeMedida { get; set; }
        public virtual DbSet<ItsMenu> Menu { get; set; }
    }
}
