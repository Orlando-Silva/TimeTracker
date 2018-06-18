#region --Using--
using System.Collections.Generic;
#endregion

namespace Controlador.BaseManager.Interfaces
{
    public interface IBaseManager<T> where T : class
    {

        #region --Métodos--
        void Inserir(T entidade);
        void Inativar(T entidade);
        void Atualizar(T entidade);
        T Carregar(int ID);
        List<T> CarregarTodos();
        #endregion

    }
}
