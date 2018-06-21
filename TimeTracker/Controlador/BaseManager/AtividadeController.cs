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
    public class AtividadeController : IBaseManager<Atividade> , IAtividadeController<Atividade>
    {

        #region --Atributos--
        private readonly Contexto contexto;
        #endregion

        #region --Construtor--
        public AtividadeController()
        {
            contexto = new Contexto();
        }
        #endregion

        #region --IBaseManager--
        public Atividade Carregar(int ID) => contexto.Atividades.Where(_ => _.ID == ID).FirstOrDefault();

        public Atividade CarregaComPredicato(Expression<Func<Atividade, bool>> predicate) => contexto.Atividades.Where(predicate).FirstOrDefault();

        public List<Atividade> CarregarTodos() => contexto.Atividades.ToList();

        public List<Atividade> CarregaListaComPredicato(Expression<Func<Atividade, bool>> predicate) => contexto.Atividades.Where(predicate).ToList();

        public void Atualizar(Atividade entidade)
        {
            contexto.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Inserir(Atividade entidade)
        {
            contexto.Atividades.Add(entidade);
            contexto.SaveChanges();
        }
        #endregion

    }
}
