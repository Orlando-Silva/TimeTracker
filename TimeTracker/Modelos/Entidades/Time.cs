#region --Using
using Modelos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Modelos.Entidades
{
    public class Time
    {
        #region --Atributos--
        public int ID { get; set; }
        Genericos.Status Status { get; set; }
        #endregion

        #region --Construtor--
        public Time()
        {

        }
        #endregion
    }
}
