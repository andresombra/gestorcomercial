using Gestor.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Gestor.Data.Config
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.FornecedorId).HasDefaultValue(0);
            builder.Property(p => p.CategoriaId).HasDefaultValue(0);
            builder.Property(p => p.UnidadeId).HasDefaultValue(0);
            builder.Property(p => p.ValorCusto).HasDefaultValue(0);
            builder.Property(p => p.ValorVenda).HasDefaultValue(0);
            builder.Property(p => p.QtdeEstoque).HasDefaultValue(0);

            builder.HasOne<Unidade>(u => u.Unidade)
                   .WithMany(p => p.Produtos)
                   .HasForeignKey(i => i.UnidadeId)
                   .HasPrincipalKey(i => i.Id);

            builder.HasOne<Categoria>(u => u.Categoria)
                   .WithMany(p => p.Produtos)
                   .HasForeignKey(i => i.CategoriaId)
                   .HasPrincipalKey(i => i.Id);

            builder.HasOne<Pessoa>(u => u.Fornecedor)
                   .WithMany(p => p.Produtos)
                   .HasForeignKey(i => i.FornecedorId)
                   .HasPrincipalKey(i => i.Id);

            builder.ToTable("produto");
        }
    }
}
