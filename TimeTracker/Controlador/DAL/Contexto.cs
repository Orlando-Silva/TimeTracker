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
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Time> Time { get; set; }
        public DbSet<Membro> Membro { get; set; }
        #endregion

    }
}
