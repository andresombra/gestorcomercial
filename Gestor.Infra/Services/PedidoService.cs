using Gestor.Infra.Interface;
using Gestor.Infra.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Gestor.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestor.Infra.Services
{
    public class PedidoService : BaseRepository<Pedido>, IPedidoService
    {
        
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedido)
        {
            _pedidoRepository = pedido;
        }
        //private readonly IPedidoItemRepository _pedidoItemRepository;
        //private readonly IPessoaRepository _pessoaRepository;
        //private readonly IProdutoRepository _produtoRepository;
        //public PedidoService(IPedidoRepository pedido, IPedidoItemRepository pedidoItem,
        //                     IPessoaRepository pessoa, IProdutoRepository produto)
        //{
        //    _pedidoRepository = pedido;
        //    _pedidoItemRepository = pedidoItem;
        //    _pessoaRepository = pessoa;
        //    _produtoRepository = produto;
        //}

        public List<SelectListItem> SelectLista()
        {
            return _pedidoRepository.SelectLista();
        }
    }
}
