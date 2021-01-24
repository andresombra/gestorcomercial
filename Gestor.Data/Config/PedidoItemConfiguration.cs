using Gestor.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Gestor.Data.Config
{
    public class PedidoItemConfiguration
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(t => t.Id);
            builder.ToTable("pedidoitem");
        }
    }
}
