using Gestor.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Gestor.Data.Config
{
    public class TipoPessoaConfiguration : IEntityTypeConfiguration<TipoPessoa>
    {
        public void Configure(EntityTypeBuilder<TipoPessoa> builder)
        {
            builder.HasKey(t => t.Id);
            builder.ToTable("tipopessoa");

            builder.HasData(
                new TipoPessoa() { Id = 1, NomeTipoPessoa = "Cliente", DataInclusao = DateTime.UtcNow },
                new TipoPessoa() { Id = 2, NomeTipoPessoa = "Fornecedor", DataInclusao = DateTime.UtcNow },
                new TipoPessoa() { Id = 3, NomeTipoPessoa = "Vendedor", DataInclusao = DateTime.UtcNow },
                new TipoPessoa() { Id = 4, NomeTipoPessoa = "Transportadora", DataInclusao = DateTime.UtcNow },
                new TipoPessoa() { Id = 5, NomeTipoPessoa = "Entregador", DataInclusao = DateTime.UtcNow });
        }
    }
}
