#region --Using--
using Modelos.Enums;
using System;
#endregion

namespace Modelos.Entidades
{
    public class Usuario
    {
        #region --Atributos--
        public int ID { get; set; }
        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public DateTime Criado { get; private set; }
        public Genericos.Status Status { get; private set; }   
        #endregion

        #region --Construtor--
        public Usuario(string nome, string login, string senha,DateTime criado, Genericos.Status status)
        {
            this.Nome = nome;
            this.Login = login;
            this.Senha = senha;
            this.Status = status;
            this.Criado = criado;
        }
        #endregion
    }
}
