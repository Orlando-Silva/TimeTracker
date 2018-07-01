#region --Using--
using Modelos.Entidades;
using System;
using System.Collections.Generic;
#endregion

namespace BusinessLogic.Services.Interfaces
{
    public interface IPeriodoService
    {

        #region --Carregar--
        Periodo Carrega(int ID);
        List<Periodo> CarregaPorAtividade(int atividadeID);
        #endregion

        #region --Inserir--
        void Inserir(DateTime inicio, DateTime fim, int atividadeID);
        Periodo Preparar(DateTime inicio, DateTime fim, int atividadeID);
        #endregion

        #region --Atualizar--

        #endregion

        #region --Outros--

        #endregion

    }
}
