using System;
using System.Collections.Generic;
using System.Linq;
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

            foreach (var item in builder.Model.GetEntityTypes().SelectMany(p => p.GetProperties().Where(pr => pr.ClrType == typeof(string))))
            {
                if (item.GetColumnType() == "nvarchar")
                    item.SetColumnType("varchar");
            }

        }

        public virtual DbSet<CentroCusto> CentroCusto { get; set; }
        public virtual DbSet<ContaBancaria> ContaBancaria { get; set; }
        public virtual DbSet<LancamentoFinanceiro> LancamentoFinanceiro { get; set; }
        public virtual DbSet<Parceiro> Parceiro { get; set; }
        public virtual DbSet<ItsMenu> Menu { get; set; }
    }
}
