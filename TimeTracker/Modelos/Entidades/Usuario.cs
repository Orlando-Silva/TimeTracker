#region --Using--
using Modelos.Enums;
using System;
using System.Collections.Generic;
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
        public List<Time> Time { get; protected set; }
        public List<Atividade> Atividades { get; protected set; }
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

        #region --Métodos--
        public void AlterarStatus(Genericos.Status status) => this.Status = status;
        
        #endregion
    }
}
