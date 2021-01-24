using Gestor.Infra.Interface;
using Gestor.Dominio.Entidades;
using System.Collections.Generic;
using Gestor.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestor.Infra.Repository
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
       
        public List<Pessoa> ListaPessoasTipoPessoa()
        {
            using (var ctx = new GestorContext())
                return ctx.Pessoas.Include(t => t.TipoPessoa).ToList();
        }
        
        public List<SelectListItem> SelectListItemPessoas(int tipoPessoa)
        {
            using (var ctx = new GestorContext())
            {
                return ctx.Pessoas
                          .Where(p=> p.TipoPessoaId == tipoPessoa)
                          .Select(a => new SelectListItem()
                          {
                              Value = a.Id.ToString(),
                              Text = a.Nome.ToString()
                          }).ToList();
            }
        }
    }
}
