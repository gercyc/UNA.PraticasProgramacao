using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNA.PraticasProgramacao.DatabaseServices.Repositorio.Context
{
    public class AncestorContext : DbContext
    {
        public AncestorContext(string connectionString) : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Aqui vamos remover a pluralização padrão do Etity Framework que é em inglês
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /*Desabilitamos o delete em cascata em relacionamentos 1:N evitando
             ter registros filhos     sem registros pai*/
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Basicamente a mesma configuração, porém em relacionamenos N:N
            modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();

            /*Toda propriedade do tipo string na entidade POCO
             seja configurado como VARCHAR no SQL Server*/
            modelBuilder.Properties<string>()
                      .Configure(p => p.HasColumnType("varchar"));

            //toda propriedade decimal tera precisao 18,2
            modelBuilder.Properties<decimal>()
                  .Configure(p => p.HasPrecision(18, 2));
        }
    }
}
