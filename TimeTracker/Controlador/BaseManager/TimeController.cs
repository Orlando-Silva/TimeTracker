#region --Using--
using System.Collections.Generic;
using Controlador.BaseManager.Interfaces;
using Modelos.Entidades;
using Controlador.DAL;
using System.Linq;
using System.Linq.Expressions;
using System;
#endregion

namespace Controlador.BaseManager
{
    public class TimeController : IBaseManager<Time>, ITimeController<Time>
    {

        #region --Atributos--
        private readonly Contexto contexto;
        #endregion

        #region --Construtor--
        public TimeController()
        {
            contexto = new Contexto();
        }
        #endregion

        #region --IBaseManager--
        public Time Carregar(int ID) => contexto.Times.Where(_ => _.ID == ID).FirstOrDefault();

        public Time CarregaComPredicato(Expression<Func<Time, bool>> predicate) => contexto.Times.Where(predicate).FirstOrDefault();

        public List<Time> CarregarTodos() => contexto.Times.ToList();

        public List<Time> CarregaListaComPredicato(Expression<Func<Time,bool>> predicate) => contexto.Times.Where(predicate).ToList();

        public void Atualizar(Time entidade)
        {
            contexto.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Inserir(Time entidade)
        {
            contexto.Times.Add(entidade);
            contexto.SaveChanges();
        }
        #endregion

        #region --ITimeController--

        #endregion

    }
}
