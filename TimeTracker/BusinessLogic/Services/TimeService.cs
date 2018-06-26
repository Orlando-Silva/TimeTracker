#region --Using--
using BusinessLogic.Services.Interfaces;
using Controlador.BaseManager;
using Modelos.Entidades;
using Modelos.Enums;
using System.Collections.Generic;
#endregion

namespace BusinessLogic.Services
{
    public class TimeService : ITimeService
    {
        #region --Atributos--
        private readonly TimeController timeController;
        #endregion

        #region --Construtor--
        public TimeService()
        {
            timeController = new TimeController();
        }
        #endregion

        #region --ITimeService--
        public void Inserir(Usuario criador, List<Usuario> membros) => timeController.Inserir(new Time(criador, membros));
        public void Inserir(int ID, List<Usuario> membros)
        {
            var time = timeController.Carregar(ID);
            time.InserirMembros(membros);
            timeController.Atualizar(time);
        }

        public List<Usuario> CarregaMembros(int ID) => timeController.CarregaComPredicato(_ => _.ID == ID).Membros;

        public List<Time> CarregaPorStatus(Genericos.Status status) => timeController.CarregaListaComPredicato(_ => _.Status == status);
        #endregion
    }
}
