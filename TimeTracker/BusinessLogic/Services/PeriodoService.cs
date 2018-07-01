#region --Using--
using BusinessLogic.Services.Interfaces;
using Controlador.BaseManager;
using Modelos.Entidades;
using System;
using System.Collections.Generic;
#endregion

namespace BusinessLogic.Services
{
    public class PeriodoService : IPeriodoService
    {
        #region --Carregar--
        public Periodo Carrega(int ID) => new PeriodoController().Carregar(ID);

        public List<Periodo> CarregaPorAtividade(int atividadeID) => new PeriodoController().CarregaListaComPredicato(_ => _.Atividade.ID == atividadeID);
        
        #endregion

        #region --Inserir--
        public void Inserir(DateTime inicio, DateTime fim, int atividadeID)
        {
            new PeriodoController().Inserir(Preparar(inicio, fim, atividadeID));
        }

        public Periodo Preparar(DateTime inicio, DateTime fim, int atividadeID)
        {
            return new Periodo()
            {
                AtividadeID = atividadeID,
                Inicio = inicio,
                Fim = fim
            };
        }
        #endregion
    }
}
