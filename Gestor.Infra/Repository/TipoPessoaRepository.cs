using Gestor.Dominio.Entidades;
using Gestor.Infra.Interface;

namespace Gestor.Infra.Repository
{
    public class TipoPessoaRepository : BaseRepository<TipoPessoa>, ITipoPessoaRepository
    {
        //private GestorContext ctx = new GestorContext();

        //public async Task<Retorno> Incluir(TipoPessoa obj)
        //{

        //    var retorno = new Retorno();
        //    try
        //    {
        //        obj.DataInclusao = DateTime.UtcNow;
        //        await ctx.Set<TipoPessoa>().AddAsync(obj);
        //        int ret = await ctx.SaveChangesAsync();
        //        retorno.Codigo = 1;
        //        retorno.Mensagem = "Incluido com sucesso.";
        //    }
        //    catch (Exception ex)
        //    {
        //        retorno.Mensagem = ex.InnerException != null ? $"Erro: {ex.InnerException.Message}, {ex.Message}"
        //            : $"Erro: {ex.Message}";
        //    }

        //    return retorno;
        //}

        //public Retorno Alterar(TipoPessoa obj)
        //{
        //    var retorno = new Retorno();
        //    try
        //    {
        //        obj.DataAtualizacao = DateTime.UtcNow;
        //        ctx.Attach(obj).State = EntityState.Modified;
        //        ctx.SaveChanges();
        //        retorno.Codigo = 1;
        //        retorno.Mensagem = "Alterado com sucesso.";
        //    }
        //    catch (Exception ex)
        //    {
        //        retorno.Mensagem = ex.InnerException != null ? $"Erro: {ex.InnerException.Message}, {ex.Message}"
        //            : $"Erro: {ex.Message}";
        //    }

        //    return retorno;
        //}

        //public List<TipoPessoa> Listar()
        //{
        //    return ctx.Set<TipoPessoa>().ToList();
        //}

        //public async Task<List<TipoPessoa>> ListarAsync()
        //{
        //    return await ctx.Set<TipoPessoa>().ToListAsync<TipoPessoa>();
        //}

        //public Retorno Excluir(int id)
        //{
        //    var retorno = new Retorno();
        //    try
        //    {
        //        var obj = ctx.Set<TipoPessoa>().Find(id);
        //        ctx.Set<TipoPessoa>().Remove(obj);
        //        ctx.SaveChanges();
        //        retorno.Codigo = 1;
        //        retorno.Mensagem = "Registro excluido.";
        //    }
        //    catch (Exception ex)
        //    {
        //        retorno.Mensagem = ex.InnerException != null ? $"Erro: {ex.InnerException.Message}, {ex.Message}"
        //            : $"Erro: {ex.Message}";
        //    }

        //    return retorno;
        //}

        //public TipoPessoa Buscar(int id)
        //{
        //    return ctx.Set<TipoPessoa>().Find(id);
        //}
    }
}
