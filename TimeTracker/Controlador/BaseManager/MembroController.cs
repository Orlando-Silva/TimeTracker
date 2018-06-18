#region --Using--
using Controlador.BaseManager.Interfaces;
using Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Controlador.BaseManager
{
    public class MembroController : IBaseManager<Membro>
    {
        public void Atualizar(Membro entidade)
        {
            throw new NotImplementedException();
        }

        public Membro Carregar(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Membro> CarregarTodos()
        {
            throw new NotImplementedException();
        }

        public void Inativar(Membro entidade)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Membro entidade)
        {
            throw new NotImplementedException();
        }
    }
}
