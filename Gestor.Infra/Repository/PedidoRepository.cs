using Gestor.Data;
using Gestor.Dominio.Entidades;
using Gestor.Infra.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestor.Infra.Repository
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public List<SelectListItem> SelectLista()
        {
            using (var ctx = new GestorContext())
            {
                return ctx.Pessoas
                          .Select(a => new SelectListItem()
                          {
                              Value = a.Id.ToString(),
                              Text = a.Nome.ToString()
                          }).ToList();
            }
        }
    }
}
