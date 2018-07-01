#region --Using--
using Modelos.Enums;
using System;
using System.Collections.Generic;
#endregion

namespace Modelos.Entidades
{
    public class Usuario
    {

        #region --Atributos--
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime Criado { get; set; }
        public Genericos.Status Status { get; set; }
        public List<Atividade> Atividades { get; set; }
        #endregion

    }
}
