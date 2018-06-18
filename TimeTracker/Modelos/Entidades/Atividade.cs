#region --Using--
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
