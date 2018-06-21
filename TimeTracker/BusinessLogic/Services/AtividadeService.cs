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

        #region --IAtividadeService--
        public void Inserir(string descricao)
        {
            Validar(descricao);
            var atividade = new Atividade(descricao);
            new AtividadeController().Inserir(atividade);               
        }

        public void Inserir(string descricao, DateTime completada, List<Periodo> periodos)
        {
            Validar(descricao,completada);
            var atividade = new Atividade(descricao,completada,periodos);
            new AtividadeController().Inserir(atividade);

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
