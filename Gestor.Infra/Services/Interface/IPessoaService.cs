using Gestor.Dominio.Entidades;
using Gestor.Infra.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestor.Infra.Services.Interface
{
    public interface IPessoaService : IBaseRepository<Pessoa>
    {
        List<Pessoa> ListaPessoasTipoPessoa();

        List<SelectListItem> SelectListItemPessoas(int tipoPessoa);

    }
}
