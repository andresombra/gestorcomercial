using Gestor.Dominio.Entidades;
using Gestor.Infra.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor.Infra.Services.Interface
{
    public interface IPedidoService : IBaseRepository<Pedido>
    {
        List<SelectListItem> SelectLista();

        //IPedidoRepository _PedidoRepository { get; set; }
        // IPedidoItemRepository _PedidoItemRepository { get; set; }
        //IPessoaRepository _PessoaRepository { get; set; }
        // IProdutoRepository _ProdutoRepository { get; set; }
    }
}
