#region --Using--
using Controlador.BaseManager.Interfaces;
using Controlador.DAL;
using Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
#endregion

namespace Controlador.BaseManager
{
    public class UsuarioController : IBaseManager<Usuario> , IUsuarioController<Usuario>
    {
        #region --Atributos--
        private static readonly Contexto contexto;
        #endregion

        #region --Construtor--
        static UsuarioController()
        {
            contexto = new Contexto();
        }
        #endregion

        #region --IBaseManager--
        public Usuario Carregar(int ID) => contexto.Usuarios.Where(_ => _.ID == ID).FirstOrDefault();

        public Usuario CarregaComPredicato(Expression<Func<Usuario , bool>> predicate) => contexto.Usuarios.Where(predicate).FirstOrDefault();

        public List<Usuario> CarregarTodos() => contexto.Usuarios.ToList();

        public List<Usuario> CarregaListaComPredicato(Expression<Func<Usuario , bool>> predicate) => contexto.Usuarios.Where(predicate).ToList();

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
