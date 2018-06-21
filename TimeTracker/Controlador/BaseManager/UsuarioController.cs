#region --Using--
using Controlador.BaseManager.Interfaces;
using Controlador.DAL;
using Modelos.Entidades;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Controlador.BaseManager
{
    public class UsuarioController : IBaseManager<Usuario> , IUsuarioController<Usuario>
    {

        #region --Atributos--
        private readonly Contexto contexto;
        #endregion

        #region --Construtor--
        public UsuarioController()
        {
            contexto = new Contexto();
        }
        #endregion

        #region --IBaseManager--
        public Usuario Carregar(int ID) => contexto.Usuarios.Where(_ => _.ID == ID).FirstOrDefault();

        public List<Usuario> CarregarTodos() => contexto.Usuarios.ToList();

        public void Atualizar(Usuario entidade)
        {
            contexto.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Inserir(Usuario entidade)
        {
            contexto.Usuarios.Add(entidade);
            contexto.SaveChanges();
        }
        #endregion

        #region --IUsuarioController-
        public bool LoginExiste(string login) => contexto.Usuarios.Any(_ => _.Login == login);

        public bool LoginValido(string login, string senha) => contexto.Usuarios.Any(_ => _.Login == login && _.Senha == senha);
        #endregion
    }
}
