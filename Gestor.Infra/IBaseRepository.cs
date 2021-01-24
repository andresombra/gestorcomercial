using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Infra
{
    public interface IBaseRepository<T> where T:class
    {
        Retorno Incluir(T obj);
        Task<Retorno> IncluirAsync(T obj, Type objetoclass = null);
        Retorno IncluirRanger(List<T> obj);
        Retorno Alterar(T obj);
        List<T> Listar();
        Task<List<T>> ListarAsync();
        Retorno Excluir(int id);
        Retorno Excluir(Guid id);
        T Buscar(int id);
    }
}
