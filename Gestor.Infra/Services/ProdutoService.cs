using Gestor.Dominio.Entidades;
using Gestor.Infra.Interface;
using Gestor.Infra.Services.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor.Infra.Services
{
    public class ProdutoService : BaseRepository<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public List<SelectListItem> SelectListItemProdutos()
        {
            return _produtoRepository.SelectListItemProdutos();
        }
    }
}
