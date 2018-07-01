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
    public class PeriodoController : IBaseManager<Periodo>
    {
        #region --Atributos--
        private readonly Contexto contexto;
        #endregion

        #region --Construtor--
        public PeriodoController()
        {
            contexto = new Contexto();
        }
        #endregion

        #region --IBaseManager--
        public Periodo Carregar(int ID) => contexto.Periodos.Where(_ => _.ID == ID).FirstOrDefault();

        public Periodo CarregaComPredicato(Expression<Func<Periodo, bool>> predicate) => contexto.Periodos.Where(predicate).FirstOrDefault();

        public List<Periodo> CarregarTodos() => contexto.Periodos.ToList();

        public List<Periodo> CarregaListaComPredicato(Expression<Func<Periodo, bool>> predicate) => contexto.Periodos.Where(predicate).ToList();

        public void Atualizar(Periodo entidade)
        {
            contexto.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Inserir(Periodo entidade)
        {
            contexto.Periodos.Add(entidade);
            contexto.SaveChanges();
        }
        #endregion
    }
}
