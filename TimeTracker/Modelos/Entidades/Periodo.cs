#region --Using--
using System;
#endregion

namespace Modelos.Entidades
{
    public class Periodo
    {

        #region --Atributos--
        public int ID { get; set; }
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }
        #endregion

        #region --Construtores--
        public Periodo(DateTime inicio, DateTime fim)
        {
            this.Inicio = inicio;
            this.Fim = fim;
        }
        public Periodo(DateTime inicio)
        {
            this.Inicio = inicio;
        }
        #endregion

    }
}
