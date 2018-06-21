#region --Using
using Modelos.Enums;
using System;
using System.Collections.Generic;
#endregion

namespace Modelos.Entidades
{
    public class Time
    {
        #region --Atributos--
        public int ID { get; set; }
        public Usuario Criador { get; set; }
        public List<Usuario> Membros { get; set; }
        public DateTime Criado { get; set; }
        Genericos.Status Status { get; set; }
        #endregion

        #region --Construtor--
        public Time()
        {

        }
        #endregion
    }
}
