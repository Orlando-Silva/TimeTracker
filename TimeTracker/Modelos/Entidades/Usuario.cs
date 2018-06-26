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
        public List<Time> Time { get; private set; }
        public List<Atividade> Atividades { get; private set; }
        #endregion

        #region --Construtor--
        public Usuario()
        {

        }

        public Usuario(string nome, string login, string senha)
        {
            this.Nome = nome;
            this.Login = login;
            this.Senha = senha;
            this.Status = Genericos.Status.Ativo;
            this.Criado = DateTime.UtcNow;
        }
        #endregion

        #region --Métodos--
        public void Atualizar(Genericos.Status status) => this.Status = status;
        
        public void Atualizar(string nome, string login, string senha)
        {
            if( !String.IsNullOrWhiteSpace(nome))
                this.Nome = nome;

            if ( !String.IsNullOrWhiteSpace(login))
                this.Login = login;

            if ( !String.IsNullOrWhiteSpace(senha))
                this.Senha = senha;
        }
        #endregion

    }
}
