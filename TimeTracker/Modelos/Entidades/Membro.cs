#region --Using--
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Enums;
#endregion

namespace Modelos.Entidades
{
    public class Membro : Usuario
    {
        #region --Atributos--
        public int ID { get; set; }
        public Time Time { get; protected set; }
        public Atividade Atividade { get; protected set; }
        #endregion

        #region --Construtor--
        public Membro(string nome, string login, string senha, Genericos.Status status) : base(nome, login, senha, status)
        {

        }
        #endregion
    }
}
