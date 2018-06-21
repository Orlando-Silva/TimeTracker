#region --Using--
using BusinessLogic.Services.Interfaces;
using Controlador.BaseManager;
using Modelos.Entidades;
using System.Collections.Generic;
#endregion

namespace BusinessLogic.Services
{
    public class TimeService : ITimeService
    {

        #region --ITimeService--
        public void Inserir(Usuario criador, List<Usuario> membros) => new TimeController().Inserir(new Time(criador, membros));
        #endregion

    }
}
