#region --Using--
using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using Modelos.Entidades;
using Controlador.BaseManager;
using Helpers;
#endregion

namespace BusinessLogic.Services
{
    public class AtividadeService : IAtividadeService
    {
        #region --Atributos--
        private readonly AtividadeController atividadeController;
        #endregion

        #region --Construtor--
        public AtividadeService()
        {
            atividadeController = new AtividadeController();
        }
        #endregion

        #region --IAtividadeService--
        public void Inserir(string descricao)
        {
            Validar(descricao);
            atividadeController.Inserir(new Atividade(descricao));               
        }

        public void Inserir(string descricao, DateTime completada, List<Periodo> periodos)
        {
            Validar(descricao,completada);
            atividadeController.Inserir(new Atividade(descricao, completada, periodos));
        }

        public void Validar(string descricao)
        {
            if (String.IsNullOrWhiteSpace(descricao))
                throw new NullReferenceException("A descrição da atividade não pode ser nula!");

            if (descricao.Length > 128)
                throw new Exception("O tamanho do campo descrição excedeu os limites");
        }

        public void Validar(string descricao, DateTime completada)
        {
            Validar(descricao);

            if (DateTimeHelpers.IsDataMaiorQueAtual(completada))
                throw new Exception("A data em que a atividade foi completada não pode ser maior que a data atual.");

        }
        #endregion

    }
}
