using Gestor.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Gestor.Data.Config
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne<TipoPessoa>(u => u.TipoPessoa)
                   .WithMany(p => p.Pessoas)
                   .HasForeignKey(i => i.TipoPessoaId);
            
            builder.ToTable("pessoa");

            builder.HasData( 
                new Pessoa() { Id = 1, TipoPessoaId = 1, Nome = "CLIENTE", DataInclusao = DateTime.UtcNow },
                new Pessoa() { Id = 2, TipoPessoaId = 2, Nome = "FORNECEDOR", DataInclusao = DateTime.UtcNow },
                new Pessoa() { Id = 3, TipoPessoaId = 3, Nome = "VENDEDOR", DataInclusao = DateTime.UtcNow });
        }
    }
}
