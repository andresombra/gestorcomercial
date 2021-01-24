using Gestor.Dominio.Entidades;
using Gestor.Infra.Interface;
using Gestor.Infra.Services.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor.Infra.Services
{
    public class PessoaService : BaseRepository<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository _pessoaRepository)
        {
            this._pessoaRepository = _pessoaRepository;
        }
        
        public List<Pessoa> ListaPessoasTipoPessoa()
        {
            return _pessoaRepository.ListaPessoasTipoPessoa();
        }

        public List<SelectListItem> SelectListItemPessoas(int tipoPessoa)
        {
            return _pessoaRepository.SelectListItemPessoas(tipoPessoa);
        }
    }
}
