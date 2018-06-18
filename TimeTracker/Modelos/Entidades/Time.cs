#region --Using
using Modelos.Enums;
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
