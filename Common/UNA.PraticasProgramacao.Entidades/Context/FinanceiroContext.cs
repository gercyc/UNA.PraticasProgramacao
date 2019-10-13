namespace UNA.PraticasProgramacao.Entidades
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using UNA.PraticasProgramacao.DatabaseServices.Repositorio.Context;

    public partial class FinanceiroContext : AncestorContext
    {
        public FinanceiroContext()
            : base("name=ControleFinanceiro")
        {
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaProduto>()
                .Property(e => e.CodigoCategoria)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriaProduto>()
                .Property(e => e.DescricaoCategoria)
                .IsUnicode(false);

            modelBuilder.Entity<CentroCusto>()
                .Property(e => e.NomeCentroCusto)
                .IsUnicode(false);

            modelBuilder.Entity<CentroCusto>()
                .Property(e => e.Responsavel)
                .IsUnicode(false);

            modelBuilder.Entity<ContaBancaria>()
                .Property(e => e.Banco)
                .IsUnicode(false);

            modelBuilder.Entity<ContaBancaria>()
                .Property(e => e.Agencia)
                .IsUnicode(false);

            modelBuilder.Entity<ContaBancaria>()
                .Property(e => e.NumeroConta)
                .IsUnicode(false);

            modelBuilder.Entity<FormaPagamento>()
                .Property(e => e.DescricaoFormaPagamento)
                .IsUnicode(false);

            modelBuilder.Entity<LancamentoFinanceiro>()
                .Property(e => e.NumeroLancamento)
                .IsUnicode(false);

            modelBuilder.Entity<LancamentoFinanceiro>()
                .Property(e => e.HistoricoLancamento)
                .IsUnicode(false);

            modelBuilder.Entity<Movimento>()
                .Property(e => e.Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Movimento>()
                .HasMany(e => e.ItemMovimento)
                .WithRequired(e => e.Movimento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Parceiro>()
                .Property(e => e.NomeParceiro)
                .IsUnicode(false);

            modelBuilder.Entity<Parceiro>()
                .Property(e => e.CpfCnpj)
                .IsUnicode(false);

            modelBuilder.Entity<Parceiro>()
                .Property(e => e.NomeEndereco)
                .IsUnicode(false);

            modelBuilder.Entity<Parceiro>()
                .Property(e => e.NumeroEndereco)
                .IsUnicode(false);

            modelBuilder.Entity<Parceiro>()
                .Property(e => e.Complemento)
                .IsUnicode(false);

            modelBuilder.Entity<Parceiro>()
                .Property(e => e.Bairro)
                .IsUnicode(false);

            modelBuilder.Entity<Parceiro>()
                .Property(e => e.Municipio)
                .IsUnicode(false);

            modelBuilder.Entity<Parceiro>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Produtos>()
                .Property(e => e.CodigoProduto)
                .IsUnicode(false);

            modelBuilder.Entity<Produtos>()
                .Property(e => e.DescricaoProduto)
                .IsUnicode(false);

            modelBuilder.Entity<Produtos>()
                .Property(e => e.Ncm)
                .IsUnicode(false);

            modelBuilder.Entity<TipoMovimento>()
                .Property(e => e.NomeTipoMovimento)
                .IsUnicode(false);

            modelBuilder.Entity<TipoMovimento>()
                .Property(e => e.Observacoes)
                .IsUnicode(false);

            modelBuilder.Entity<UnidadeMedida>()
                .Property(e => e.CodUnidadeMedida)
                .IsUnicode(false);

            modelBuilder.Entity<UnidadeMedida>()
                .Property(e => e.NomeUnidadeMedida)
                .IsUnicode(false);
        }
    }
}
