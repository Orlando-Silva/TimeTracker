#region --Using--
using Modelos.Entidades;
using System;
using System.Collections.Generic;
#endregion

namespace BusinessLogic.Services.Interfaces
{
    public interface IAtividadeService
    {

        #region --Carregar--
        Atividade Carrega(int ID);
        List<Atividade> CarregaAtividadePorUsuario(int usuarioID);
        List<Atividade> CarregaAtividadePorUsuarioStatus(int usuarioID, Atividade.AtividadeStatus status);
        #endregion

        #region --Inserir--
        void Inserir(string titulo, string descricao, int usuarioID);
        void Validar(string titulo, string descricao, int usuarioID);
        Atividade Preparar(string titulo, string descricao, int usuarioID);
        #endregion

        #region --Atualizar--
        void Atualizar(int ID, Atividade.AtividadeStatus status);
        void Atualizar(int ID, Periodo periodo);
        void Atualizar(int ID, List<Periodo> periodos);
        #endregion

        #region --Outros--
        int CalcularDiasGastos(int ID);
        int CalcularHorasGastas(int ID);
        int CalcularMinutosGastos(int ID);
        #endregion

    }
}
