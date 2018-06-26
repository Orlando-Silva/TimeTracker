#region --Using--
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
#endregion

namespace Controlador.BaseManager.Interfaces
{
    public interface IBaseManager<T> where T : class
    {
        #region --Métodos--
        void Inserir(T entidade);
        void Atualizar(T entidade);
        T Carregar(int ID);
        T CarregaComPredicato(Expression<Func<T,bool>> predicate);
        List<T> CarregaListaComPredicato(Expression<Func<T, bool>> predicate);
        List<T> CarregarTodos();
        #endregion
    }
}
