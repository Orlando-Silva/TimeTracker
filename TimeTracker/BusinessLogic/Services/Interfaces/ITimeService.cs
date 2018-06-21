#region --Using--
using Modelos.Entidades;
using System.Collections.Generic;
#endregion

namespace BusinessLogic.Services.Interfaces
{
    public interface ITimeService
    {

        #region --Métodos--
        void Inserir(Usuario criador, List<Usuario> membros);
        void Inserir(int ID, List<Usuario> membros);
        List<Usuario> CarregaMembros(int ID);
        #endregion

    }
}
