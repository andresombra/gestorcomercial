using Gestor.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Infra
{
    /// <summary>
    /// Somente para exemplo que uma Interface na versao nova do C# pode ser implementado metodos
    /// </summary>
    public interface IRepository<T> where T : class
    {
        public Retorno Incluir(T obj)
        {
            var retorno = new Retorno();
            try
            {
                using (var ctx = new GestorContext())
                {
                    ctx.Set<T>().Add(obj);
                    int ret = ctx.SaveChanges();
                    return retorno.Ok("Incluido com sucesso.");
                }
            }
            catch (Exception ex) { return new Retorno(ex); }
        }

        public async Task<Retorno> IncluirAsync(T obj, Type objetoclass = null)
        {
            var retorno = new Retorno();
            try
            {
                using (var ctx = new GestorContext())
                {
                    ctx.Set<T>().Add(obj);
                    int ret = await ctx.SaveChangesAsync();
                    return retorno.Ok("Incluido com sucesso.");
                }
            }
            catch (Exception ex) { return new Retorno(ex); }
        }

        public Retorno IncluirRanger(List<T> obj)
        {
            var retorno = new Retorno();
            try
            {
                using (var ctx = new GestorContext())
                {
                    //obj.ForEach(peditens=> { 
                    //    ctx.Set<T>().Add(peditens);
                    //    int ret = ctx.SaveChanges();
                    //});
                    ctx.Set<T>().AddRange(obj);
                    int ret = ctx.SaveChanges();
                    return retorno.Ok("Incluidos com sucesso.");
                }
            }
            catch (Exception ex) { return retorno.Error(ex); }
        }

        public Retorno Alterar(T obj)
        {
            var retorno = new Retorno();
            try
            {
                using (var ctx = new GestorContext())
                {
                    ctx.Set<T>().Update(obj);
                    ctx.SaveChanges();
                    retorno.Codigo = 1;
                    retorno.Mensagem = "Alterado com sucesso.";
                }
            }
            catch (Exception ex)
            {
                retorno.Mensagem = ex.InnerException != null ? $"Erro: {ex.InnerException.Message}, {ex.Message}"
                    : $"Erro: {ex.Message}";
            }

            return retorno;
        }

        public List<T> Listar()
        {
            using (var ctx = new GestorContext())
            {
                return ctx.Set<T>().ToList();
            }
        }

        public async Task<List<T>> ListarAsync()
        {
            using (var ctx = new GestorContext())
            {
                return await ctx.Set<T>().ToListAsync<T>();
            }
        }

        public Retorno Excluir(int id)
        {
            try
            {
                using (var ctx = new GestorContext())
                {
                    var obj = ctx.Set<T>().Find(id);
                    ctx.Set<T>().Remove(obj);
                    ctx.SaveChanges();
                    return new Retorno("Registro excluido.");
                }
            }
            catch (Exception ex)
            {
                return new Retorno(ex);
            }
        }

        public Retorno Excluir(Guid id)
        {
            try
            {
                using (var ctx = new GestorContext())
                {
                    var obj = ctx.Set<T>().Find(id);
                    ctx.Set<T>().Remove(obj);
                    ctx.SaveChanges();
                    return new Retorno("Registro excluido.");
                }
            }
            catch (Exception ex)
            {
                return new Retorno(ex);
            }
        }

        public T Buscar(int id)
        {
            using (var ctx = new GestorContext())
            {
                return ctx.Set<T>().Find(id);
            }
        }
    }
}
