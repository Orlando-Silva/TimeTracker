#region --Using--
using System;
#endregion

namespace Modelos.Entidades
{
    public class Periodo
    {
        #region --Atributos--
        public int ID { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int AtividadeID { get; set; }
        public virtual Atividade Atividade { get; set; }
        #endregion
    }
}
