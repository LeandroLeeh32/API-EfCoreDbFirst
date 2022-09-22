using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EfCoreDbFirst.Infrastructure.DataModels
{
    public partial class leandroDbContext : DbContext
    {
        public leandroDbContext()
        {
        }

        public leandroDbContext(DbContextOptions<leandroDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCompra> TbCompras { get; set; } = null!;
        public virtual DbSet<TbPessoa> TbPessoas { get; set; } = null!;
        public virtual DbSet<TbPessoaFisica> TbPessoaFisicas { get; set; } = null!;
        public virtual DbSet<TbPessoaJuridica> TbPessoaJuridicas { get; set; } = null!;
        public virtual DbSet<TbProduto> TbProdutos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost; Database=leandro; user id=postgres; password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCompra>(entity =>
            {
                entity.HasKey(e => e.Idcompra)
                    .HasName("tb_compra_pkey");

                entity.ToTable("tb_compra");

                entity.Property(e => e.Idcompra).HasColumnName("idcompra");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Idpessoa).HasColumnName("idpessoa");

                entity.Property(e => e.Idproduto).HasColumnName("idproduto");

                entity.HasOne(d => d.IdpessoaNavigation)
                    .WithMany(p => p.TbCompras)
                    .HasForeignKey(d => d.Idpessoa)
                    .HasConstraintName("fk_tb_pessoa_tb_compra");

                entity.HasOne(d => d.IdprodutoNavigation)
                    .WithMany(p => p.TbCompras)
                    .HasForeignKey(d => d.Idproduto)
                    .HasConstraintName("fk_tb_produto_tb_compra");
            });

            modelBuilder.Entity<TbPessoa>(entity =>
            {
                entity.HasKey(e => e.Idpessoa)
                    .HasName("tb_pessoa_pkey");

                entity.ToTable("tb_pessoa");

                entity.Property(e => e.Idpessoa).HasColumnName("idpessoa");

                entity.Property(e => e.Celular)
                    .HasMaxLength(20)
                    .HasColumnName("celular");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TbPessoaFisica>(entity =>
            {
                entity.HasKey(e => e.Idpessoafisica)
                    .HasName("tb_pessoa_fisica_pkey");

                entity.ToTable("tb_pessoa_fisica");

                entity.Property(e => e.Idpessoafisica).HasColumnName("idpessoafisica");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(20)
                    .HasColumnName("cpf");

                entity.Property(e => e.Idpessoa).HasColumnName("idpessoa");

                entity.Property(e => e.Rg)
                    .HasMaxLength(101)
                    .HasColumnName("rg");

                entity.HasOne(d => d.IdpessoaNavigation)
                    .WithMany(p => p.TbPessoaFisicas)
                    .HasForeignKey(d => d.Idpessoa)
                    .HasConstraintName("fk_tb_pessoa_tb_pessoa_fisica");
            });

            modelBuilder.Entity<TbPessoaJuridica>(entity =>
            {
                entity.HasKey(e => e.Idpessoajuridica)
                    .HasName("tb_pessoa_juridica_pkey");

                entity.ToTable("tb_pessoa_juridica");

                entity.Property(e => e.Idpessoajuridica).HasColumnName("idpessoajuridica");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(20)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Idpessoa).HasColumnName("idpessoa");

                entity.HasOne(d => d.IdpessoaNavigation)
                    .WithMany(p => p.TbPessoaJuridicas)
                    .HasForeignKey(d => d.Idpessoa)
                    .HasConstraintName("fk_tb_pessoa_tb_pessoa_juridica");
            });

            modelBuilder.Entity<TbProduto>(entity =>
            {
                entity.HasKey(e => e.Idproduto)
                    .HasName("tb_produto_pkey");

                entity.ToTable("tb_produto");

                entity.Property(e => e.Idproduto).HasColumnName("idproduto");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .HasColumnName("descricao");

                entity.Property(e => e.Preco)
                    .HasPrecision(10, 2)
                    .HasColumnName("preco");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
