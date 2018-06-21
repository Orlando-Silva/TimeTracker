#region --Using--
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
        public Usuario Criador { get; private set; }
        public List<Usuario> Membros { get; private set; }
        public DateTime Criado { get; private set; }
        public Genericos.Status Status { get; private set; }
        #endregion

        #region --Construtor--
        public Time(Usuario criador, List<Usuario> membros)
        {
            this.Criador = criador;
            this.Membros = membros;
            this.Status = Genericos.Status.Ativo;
            this.Criado = DateTime.UtcNow;
        }
        #endregion

        #region --Métodos
        public void InserirMembros(List<Usuario> membros) => this.Membros.AddRange(membros);
        
        #endregion

    }
}
