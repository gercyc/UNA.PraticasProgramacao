/*
    UNA - Tecnologia em Analise e Desenvolvimento de sistemas
    Disciplina:Práticas de Programação
    Professor: Luiz Eduardo Carneiro
    Período: 2º semestre/2019
    Autores: Gercy Campos
    Informações: Classe de controle do acesso ao banco, herdando de IdentityDbContext que já contem as entidades de controle de acesso. Usando ASP.NET Identity Core
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UNA.PraticasProgramacao.Core.Entidades;

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

            //configura as colunas que são criadas pelo migrations para utilizar o datatype 'varchar'
            foreach (var item in builder.Model.GetEntityTypes().SelectMany(p => p.GetProperties().Where(pr => pr.ClrType == typeof(string))))
            {
                if (item.GetColumnType() == "nvarchar")
                    item.SetColumnType("varchar");
            }

        }

        #region Entitades que serão controladas por esta classe de acesso a banco via entity framework

        public virtual DbSet<CentroCusto> CentroCusto { get; set; }
        public virtual DbSet<ContaBancaria> ContaBancaria { get; set; }
        public virtual DbSet<LancamentoFinanceiro> LancamentoFinanceiro { get; set; }
        public virtual DbSet<ItsMenu> Menu { get; set; }
        #endregion
    }
}
