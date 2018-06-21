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

        #region --ITimeService--
        public void Inserir(Usuario criador, List<Usuario> membros) => new TimeController().Inserir(new Time(criador, membros));
        public void Inserir(int ID, List<Usuario> membros)
        {
            var time = new TimeController().Carregar(ID);
            time.InserirMembros(membros);
            new TimeController().Atualizar(time);
        }

        public List<Usuario> CarregaMembros(int ID) => new TimeController().CarregaComPredicato(_ => _.ID == ID).Membros;

        public List<Time> CarregaPorStatus(Genericos.Status status) => new TimeController().CarregaListaComPredicato(_ => _.Status == status);

        #endregion

    }
}
