#region --Using--
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace Modelos.Entidades
{
    public class Atividade
    {
        #region --Atributos--
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Criada { get; set; }
        public AtividadeStatus Status { get; set; }
        public List<Periodo> Periodos { get; set; }
        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }
        #endregion

        #region --Enums--
        public enum AtividadeStatus
        {
            [Description("Pendente")]
            Pendente = 0,
            [Description("Em Andamento")]
            EmAndamento = 1,
            [Description("Concluída")]
            Concluida = 1
        }
        #endregion

    }
}
