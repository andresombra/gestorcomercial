using Gestor.Dominio.Entidades;
using Gestor.Infra.Interface;
using Gestor.Infra.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor.Infra.Services
{
    public class PedidoItemService : BaseRepository<PedidoItem>, IPedidoItemService
    {
        //private readonly IPedidoItemRepository _pedidoItemRepository;
        //public PedidoItemService(IPedidoItemRepository pedidoItemRepository)
        //{
        //    _pedidoItemRepository = pedidoItemRepository;
        //}

    }
}
