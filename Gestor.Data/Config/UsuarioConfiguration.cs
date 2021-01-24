using Gestor.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestor.Data.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(t => t.Id);
            builder.ToTable("usuario");

            builder.HasData(
                new Usuario() { Id = 1, NomeUsuario = "Administrador", Login="admin", Senha = "admin" },
                new Usuario() { Id = 2, NomeUsuario = "Operador", Login = "oper", Senha = "oper" },
                new Usuario() { Id = 3, NomeUsuario = "Usuario", Login = "user", Senha = "user" });
        }
    }
}
    
