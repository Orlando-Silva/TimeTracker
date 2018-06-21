#region --Using--
using Modelos.Entidades;
#endregion

namespace Controlador.BaseManager.Interfaces
{
    public interface IUsuarioController<T> where T : Usuario
    {

        #region --Métodos--
        bool LoginExiste(string login);
        bool LoginValido(string login, string senha);
        #endregion

    }
}
