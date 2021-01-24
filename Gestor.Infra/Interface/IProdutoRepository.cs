using Gestor.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestor.Infra.Interface
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        List<SelectListItem> SelectListItemProdutos();
    }
}
