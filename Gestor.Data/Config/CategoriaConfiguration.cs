using Gestor.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Gestor.Data.Config
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.NomeCategoria)
                .IsRequired()
                .HasColumnName("nm_categoria")
                .HasColumnType("varchar(100)");

            // Crio um index na propriedade de nome da categoria e marco como único,
            // ou seja, eu garato que jamais havará 2 ou mais nomes de categorias iguais
            // em nossa base
            builder.HasIndex(x => x.NomeCategoria).IsUnique();

            builder.ToTable("categoria");

            builder.HasData(
                new Categoria() { Id = -1, NomeCategoria = "Sem Categoria", DataInclusao = DateTime.UtcNow },
                new Categoria() { Id = 1, NomeCategoria = "Livros", DataInclusao = DateTime.UtcNow },
                new Categoria() { Id = 2, NomeCategoria = "Roupas", DataInclusao = DateTime.UtcNow },
                new Categoria() { Id = 3, NomeCategoria = "Bebidas", DataInclusao = DateTime.UtcNow },
                new Categoria() { Id = 4, NomeCategoria = "Eletronicos", DataInclusao = DateTime.UtcNow },
                new Categoria() { Id = 5, NomeCategoria = "Comidas", DataInclusao = DateTime.UtcNow },
                new Categoria() { Id = 9999, NomeCategoria = "Outros", DataInclusao = DateTime.UtcNow });
        }
    }
}
