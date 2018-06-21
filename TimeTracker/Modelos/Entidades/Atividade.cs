#region --Using--
using System;
using System.Collections.Generic;
#endregion

namespace Modelos.Entidades
{
    public class Atividade
    {
        #region --Atributos--
        public int ID { get; set; }
        public string Descricao { get; set; }
        public DateTime Criada { get; set; }
        public DateTime Completada { get; set; }
        public List<Periodo> Periodos { get; set; }
        #endregion

        #region --Construtor--
        public Atividade()
        {

        }
        #endregion
    }
}
