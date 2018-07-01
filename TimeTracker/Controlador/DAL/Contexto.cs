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
        public virtual DbSet<Usuario> Usuarios { get; set; }
        #endregion


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atividade>().HasRequired(a => a.Usuario)
                .WithMany(u => u.Atividades)
                .HasForeignKey(a => a.UsuarioID);
        }

    }
}
