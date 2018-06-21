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
        public string Descricao { get; private set; }
        public DateTime Criada { get; private set; }
        public DateTime Completada { get; private set; }
        public List<Periodo> Periodos { get; private set; }
        #endregion

        #region --Construtores--
        public Atividade(string descricao)
        {
            this.Descricao = descricao;
            this.Criada = DateTime.UtcNow;
        }
        public Atividade(string descricao, DateTime completada, List<Periodo> periodos)
        {
            this.Descricao = descricao;
            this.Criada = DateTime.UtcNow;
            this.Completada = completada;
            this.Periodos = periodos;
        }
        #endregion
    }
}
