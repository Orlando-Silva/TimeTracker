#region --Using--
using Modelos.Entidades;
using System;
#endregion

namespace BusinessLogic.Services.Interfaces
{
    public interface IUsuarioService
    {

        #region --Métodos--
        void Inserir(string nome, string login, string senha);
        void Validar(string nome, string login, string senha);
        void Login(string login, string senha);
        Usuario Preparar(string nome, string login, string senha);
        void Inativar(int ID);
        #endregion

    }
}
