using Gestor.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestor.Infra.Interface
{
    public interface IPessoaRepository : IBaseRepository<Pessoa>
    {
        List<Pessoa> ListaPessoasTipoPessoa();

        List<SelectListItem> SelectListItemPessoas(int tipoPessoa);
    }
}
