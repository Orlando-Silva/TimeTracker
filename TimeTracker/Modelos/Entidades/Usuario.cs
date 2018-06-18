#region --Using--
using Modelos.Enums;
#endregion

namespace Modelos.Entidades
{
    public abstract class Usuario
    {
        #region --Atributos--
        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public Genericos.Status Status { get; private set; }   
        #endregion

        #region --Construtor--
        public Usuario(string nome, string login, string senha, Genericos.Status status)
        {
            this.Nome = nome;
            this.Login = login;
            this.Senha = senha;
            this.Status = status;
        }
        #endregion
    }
}
