using Gestor.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor.Infra.Services.Interface
{
    public interface IProdutoService : IBaseRepository<Produto>
    {
        List<SelectListItem> SelectListItemProdutos();
    }
}
