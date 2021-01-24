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
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public List<SelectListItem> SelectListItemProdutos()
        {
            using (var ctx = new GestorContext())
            {
                return ctx.Produtos
                          .Select(a => new SelectListItem()
                          {
                              Value = a.Id.ToString(),
                              Text = a.NomeProduto.ToString()
                          }).ToList();
            }
        }

        //override public async Task<Retorno> IncluirAs(Produto obj)
        //{
        //    var retorno = new Retorno();
        //    try
        //    {
        //        using (var ctx = new GestorContext())
        //        {
        //            obj.DataInclusao = DateTime.UtcNow;
        //            await ctx.Produtos.AddAsync(obj);
        //            int ret = await ctx.SaveChangesAsync();
        //            retorno.Codigo = 1;
        //            retorno.Mensagem = "Incluido com sucesso.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        retorno.Mensagem = ex.InnerException != null ? $"Erro: {ex.InnerException.Message}, {ex.Message}"
        //            : $"Erro: {ex.Message}";
        //    }
        //    return retorno;
        //}

        //public override Retorno Alterar(Produto obj)
        //{
        //    var retorno = new Retorno();
        //    try
        //    {
        //        using (var ctx = new GestorContext())
        //        {
        //            obj.DataAtualizacao = DateTime.UtcNow;
        //            //ctx.Attach(obj).State = EntityState.Modified;
        //            ctx.Update(obj);
        //            ctx.SaveChanges();
        //            retorno.Codigo = 1;
        //            retorno.Mensagem = "Alterado com sucesso.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        retorno.Mensagem = ex.InnerException != null ? $"Erro: {ex.InnerException.Message}, {ex.Message}"
        //            : $"Erro: {ex.Message}";
        //    }

        //    return retorno;
        //}

        //public override List<Produto> Listar()
        //{
        //    using (var ctx = new GestorContext())
        //    {
        //        return ctx.Produtos.ToList();
        //    }
        //}

        //public override async Task<List<Produto>> ListarAsync()
        //{
        //    using (var ctx = new GestorContext())
        //        return await ctx.Produtos.ToListAsync<Produto>();
        //}

        //public override Retorno Excluir(int id)
        //{
        //    var retorno = new Retorno();
        //    try
        //    {
        //        using (var ctx = new GestorContext())
        //        {
        //            var obj = ctx.Set<Produto>().Find(id);
        //            ctx.Set<Produto>().Remove(obj);
        //            ctx.SaveChanges();
        //            retorno.Codigo = 1;
        //            retorno.Mensagem = "Registro excluido.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        retorno.Mensagem = ex.InnerException != null ? $"Erro: {ex.InnerException.Message}, {ex.Message}"
        //            : $"Erro: {ex.Message}";
        //    }

        //    return retorno;
        //}

        //public override Produto Buscar(int id)
        //{
        //    using (var ctx = new GestorContext())
        //        return ctx.Set<Produto>().Find(id);
        //}



    }
}
