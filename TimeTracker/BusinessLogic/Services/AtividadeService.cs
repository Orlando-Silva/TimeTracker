#region --Using--
using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using Modelos.Entidades;
using Controlador.BaseManager;
using Helpers;
using System.Linq;
using static Modelos.Entidades.Atividade;
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

        #region --Carregar--
        public Atividade Carrega(int ID) => atividadeController.Carregar(ID);

        public List<Atividade> CarregaAtividadePorUsuario(int usuarioID) => atividadeController.CarregaListaComPredicato(_ => _.Usuario.ID == usuarioID);

        public List<Atividade> CarregaAtividadePorUsuarioStatus(int usuarioID, Atividade.AtividadeStatus status) => atividadeController.CarregaListaComPredicato(_ => _.Usuario.ID == usuarioID && _.Status == status);
        #endregion

        #region --Inserir--
        public void Inserir(string titulo, string descricao, int usuarioID)
        {
            Validar(titulo, descricao, usuarioID);
            atividadeController.Inserir(Preparar(titulo, descricao, usuarioID));
        }

        public void Validar(string titulo, string descricao, int usuarioID)
        {
            if (String.IsNullOrWhiteSpace(titulo))
                throw new Exception("Uma atividade deve conter título.");

            if (String.IsNullOrWhiteSpace(descricao))
                throw new Exception("Uma atividade deve conter descrição");

            var atividades = CarregaAtividadePorUsuario(usuarioID) as List<Atividade>;

            if (atividades.Any(_ => _.Titulo == titulo && _.Status == AtividadeStatus.Pendente))
                throw new Exception("Não é possível cadastrar duas atividades com o mesmo nome.");

        }


        public Atividade Preparar(string titulo, string descricao, int usuarioID)
        {
            return new Atividade()
            {
                Titulo = titulo,
                Descricao = descricao,
                Criada = DateTime.UtcNow,
                UsuarioID = usuarioID,
                Status = AtividadeStatus.Pendente
            };
        }
        #endregion

        #region --Atualizar--
        public void Atualizar(int ID, Atividade.AtividadeStatus status)
        {
            var atividade = Carrega(ID) as Atividade;
            atividade.Status = status;
            atividadeController.Atualizar(atividade);
        }

        public void Atualizar(int ID, Periodo periodo)
        {
            var atividade = Carrega(ID) as Atividade;
            atividade.Periodos.Add(periodo);
            atividadeController.Atualizar(atividade);
        }

        public void Atualizar(int ID, List<Periodo> periodos)
        {
            var atividade = Carrega(ID) as Atividade;
            atividade.Periodos = periodos;
            atividadeController.Atualizar(atividade);
        }
        #endregion

        #region --Outros--
        public int CalcularDiasGastos(int ID)
        {
            var periodos = new PeriodoService().CarregaPorAtividade(ID) as List<Periodo>;
            TimeSpan dias = TimeSpan.Zero;

            foreach (Periodo periodo in periodos)
                dias += periodo.Fim.Subtract(periodo.Inicio);

            return (int)dias.TotalDays;

        }

        public int CalcularHorasGastas(int ID)
        {
            var periodos = new PeriodoService().CarregaPorAtividade(ID) as List<Periodo>;
            TimeSpan horas = TimeSpan.Zero;

            foreach (Periodo periodo in periodos)
                horas += periodo.Fim.Subtract(periodo.Inicio);

            return (int)horas.TotalHours;
        }
        public int CalcularMinutosGastos(int ID)
        {
            var periodos = new PeriodoService().CarregaPorAtividade(ID) as List<Periodo>;
            TimeSpan minutes = TimeSpan.Zero;

            foreach (Periodo periodo in periodos)
                minutes += periodo.Fim.Subtract(periodo.Inicio);

            return (int)minutes.TotalMinutes;
        }
        #endregion

        #endregion

    }
}
