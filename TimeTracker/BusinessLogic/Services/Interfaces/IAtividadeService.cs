#region --Using--
using Modelos.Entidades;
using System;
using System.Collections.Generic;
#endregion

namespace BusinessLogic.Services.Interfaces
{
    public interface IAtividadeService
    {

        #region --Métodos--
        void Inserir(string descricao);
        void Inserir(string descricao, DateTime completada, List<Periodo> periodos);
        void Validar(string descricao, DateTime completada);
        void Validar(string descricao);
        #endregion

    }
}
