#region --Using--
using Controlador.BaseManager.Interfaces;
using Controlador.DAL;
using Modelos.Entidades;
using Modelos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Controlador.BaseManager
{
    public class MembroController : IBaseManager<Membro>
    {

        #region --Atributos--
        private readonly Contexto contexto;
        #endregion

        #region --Construtor--
        public MembroController()
        {
            contexto = new Contexto();
        }
        #endregion

        #region --IBaseManager--
        public void Atualizar(Membro entidade)
        {
            contexto.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public Membro Carregar(int ID) => contexto.Membro.Where(_ => _.ID == ID).FirstOrDefault();

        public List<Membro> CarregarTodos() => contexto.Membro.ToList();

        public void Inativar(Membro entidade)
        {
            entidade.Status = Genericos.Status.Inativo;
            contexto.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Inserir(Membro entidade)
        {
            contexto.Membro.Add(entidade);
            contexto.SaveChanges();
        }
        #endregion
    }
}
