using Gestor.Dominio.Entidades;
using Gestor.Infra.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor.Infra.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public Usuario New(int? usuarioId)
        {
            return new Usuario() { UsuarioId = usuarioId };
        }
    }
}
