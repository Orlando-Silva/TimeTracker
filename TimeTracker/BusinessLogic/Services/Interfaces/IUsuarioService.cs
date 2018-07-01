#region --Using--
using Modelos.Entidades;
using Modelos.Enums;
#endregion

namespace BusinessLogic.Services.Interfaces
{
    public interface IUsuarioService
    {

        #region --Carregar--
        Usuario Carrega(int ID);
        Usuario CarregaPorLogin(string login);
        #endregion

        #region --Inserir--
        void Inserir(string nome, string login, string senha);
        void Validar(string nome, string login, string senha);
        Usuario Preparar(string nome, string login, string senha);
        #endregion

        #region --Atualizar
        void Atualizar(int ID,string nome, string login, string senha);
        void Atualizar(int ID, Genericos.Status status);
        #endregion

        #region --Outros--
        void Login(string login, string senha);    
        #endregion

    }
}
