#region --Using--
using System;
#endregion

namespace Modelos.Entidades
{
    public class Atividade
    {
        #region --Atributos--
        public int ID { get; set; }
        public DateTime Inicio { get; protected set; }
        public DateTime Fim { get; protected set; }
        #endregion

        #region --Construtor--
        public Atividade()
        {

        }
        #endregion
    }
}
