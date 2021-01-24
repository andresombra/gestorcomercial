using Gestor.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Gestor.Data.Config
{
    public class UnidadeConfiguration : IEntityTypeConfiguration<Unidade>
    {
        public void Configure(EntityTypeBuilder<Unidade> builder)
        {
            builder.HasKey(t => t.Id);
            builder.ToTable("unidade");

            builder.HasData(
                new Unidade() { Id=1,  DataInclusao = DateTime.UtcNow, NomeUnidade = "UNID" },
                new Unidade() { Id=2,  DataInclusao = DateTime.UtcNow, NomeUnidade = "CAIXA" },
                new Unidade() { Id=3,  DataInclusao = DateTime.UtcNow, NomeUnidade = "PCT" },
                new Unidade() { Id=4,  DataInclusao = DateTime.UtcNow, NomeUnidade = "LT" },
                new Unidade() { Id=5,  DataInclusao = DateTime.UtcNow, NomeUnidade = "BDJ" },
                new Unidade() { Id=6,  DataInclusao = DateTime.UtcNow, NomeUnidade = "KG" },
                new Unidade() { Id=7,  DataInclusao = DateTime.UtcNow, NomeUnidade = "ML" },
                new Unidade() { Id=8,  DataInclusao = DateTime.UtcNow, NomeUnidade = "GRFA" },
                new Unidade() { Id=9,  DataInclusao = DateTime.UtcNow, NomeUnidade = "FARDO" },
                new Unidade() { Id=10, DataInclusao = DateTime.UtcNow, NomeUnidade = "DUZIA" },
                new Unidade() { Id=11, DataInclusao = DateTime.UtcNow, NomeUnidade = "MEIA DUZIA" },
                new Unidade() { Id=12, DataInclusao = DateTime.UtcNow, NomeUnidade = "AMPOLA" },
                new Unidade() { Id=13, DataInclusao = DateTime.UtcNow, NomeUnidade = "BALDE" },
                new Unidade() { Id=14, DataInclusao = DateTime.UtcNow, NomeUnidade = "BARRA" },
                new Unidade() { Id=15, DataInclusao = DateTime.UtcNow, NomeUnidade = "BISNAGA" },
                new Unidade() { Id=16, DataInclusao = DateTime.UtcNow, NomeUnidade = "BLOCO" },
                new Unidade() { Id=17, DataInclusao = DateTime.UtcNow, NomeUnidade = "BOBINA" },
                new Unidade() { Id=18, DataInclusao = DateTime.UtcNow, NomeUnidade = "CAPSULA" },
                new Unidade() { Id=19, DataInclusao = DateTime.UtcNow, NomeUnidade = "CARTELA" },
                new Unidade() { Id=20, DataInclusao = DateTime.UtcNow, NomeUnidade = "FOLHA" },
                new Unidade() { Id=21, DataInclusao = DateTime.UtcNow, NomeUnidade = "FRASCO" },
                new Unidade() { Id=22, DataInclusao = DateTime.UtcNow, NomeUnidade = "CENTO" },
                new Unidade() { Id=23, DataInclusao = DateTime.UtcNow, NomeUnidade = "GALÃO" },
                new Unidade() { Id=24, DataInclusao = DateTime.UtcNow, NomeUnidade = "GARRAFA" },
                new Unidade() { Id=25, DataInclusao = DateTime.UtcNow, NomeUnidade = "GRAMAS" },
                new Unidade() { Id=26, DataInclusao = DateTime.UtcNow, NomeUnidade = "JOGO" },
                new Unidade() { Id=27, DataInclusao = DateTime.UtcNow, NomeUnidade = "KIT" },
                new Unidade() { Id=28, DataInclusao = DateTime.UtcNow, NomeUnidade = "LITRO" },
                new Unidade() { Id=29, DataInclusao = DateTime.UtcNow, NomeUnidade = "PACOTE" },
                new Unidade() { Id=30, DataInclusao = DateTime.UtcNow, NomeUnidade = "PALETE" },
                new Unidade() { Id=31, DataInclusao = DateTime.UtcNow, NomeUnidade = "PARES" },
                new Unidade() { Id=32, DataInclusao = DateTime.UtcNow, NomeUnidade = "PEÇA" },
                new Unidade() { Id=33, DataInclusao = DateTime.UtcNow, NomeUnidade = "RESMA" },
                new Unidade() { Id=34, DataInclusao = DateTime.UtcNow, NomeUnidade = "ROLO" },
                new Unidade() { Id=35, DataInclusao = DateTime.UtcNow, NomeUnidade = "SACO" },
                new Unidade() { Id=36, DataInclusao = DateTime.UtcNow, NomeUnidade = "SACOLA" },
                new Unidade() { Id=37, DataInclusao = DateTime.UtcNow, NomeUnidade = "TAMBOR" },
                new Unidade() { Id=38, DataInclusao = DateTime.UtcNow, NomeUnidade = "TUBO" },
                new Unidade() { Id=39, DataInclusao = DateTime.UtcNow, NomeUnidade = "VASILHAME" },
                new Unidade() { Id=40, DataInclusao = DateTime.UtcNow, NomeUnidade = "VIDRO" });
        }
    }
}
