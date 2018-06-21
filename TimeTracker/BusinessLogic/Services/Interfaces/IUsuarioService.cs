#region --Using--
using Modelos.Entidades;
using Modelos.Enums;
#endregion

namespace BusinessLogic.Services.Interfaces
{
    public interface IUsuarioService
    {

        #region --Métodos--
        void Inserir(string nome, string login, string senha);
        void Validar(string nome, string login, string senha);
        void Login(string login, string senha);
        void Atualizar(int ID,string nome, string login, string senha);
        void Atualizar(int ID, Genericos.Status status);
        Usuario Preparar(string nome, string login, string senha);

        #endregion

    }
}
