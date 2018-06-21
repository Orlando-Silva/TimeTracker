#region --Using--
using Modelos.Enums;
using System;
#endregion

namespace Modelos.Entidades
{
    public class Membro : Usuario
    {
        #region --Atributos--
        public int ID { get; set; } //TODO: Arrumar Isto.
        public Time Time { get; protected set; }
        public Atividade Atividade { get; protected set; }
        #endregion

        #region --Construtor--
        public Membro(string nome, string login, string senha, DateTime criado, Genericos.Status status) : base(nome, login, senha, criado, status)
        {

        }
        #endregion
    }
}
