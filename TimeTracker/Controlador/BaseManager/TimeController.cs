#region --Using--
using System.Collections.Generic;
using Controlador.BaseManager.Interfaces;
using Modelos.Entidades;
using Controlador.DAL;
using System.Linq;
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

        public List<Time> CarregarTodos() => contexto.Times.ToList();

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
