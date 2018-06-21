#region --Using--
using Modelos.Entidades;
using System.Data.Entity;
#endregion

namespace Controlador.DAL
{
    public class Contexto : DbContext
    {

        #region --Construtor--
        public Contexto() : base("ConnectionString")
        {

        }
        #endregion

        #region --Entidades--
        public virtual DbSet<Atividade> Atividades { get; set; }
        public virtual DbSet<Time> Time { get; set; }
        public virtual DbSet<Membro> Membro { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        #endregion

    }
}
