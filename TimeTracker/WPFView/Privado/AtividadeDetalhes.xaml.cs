#region --Using--
using BusinessLogic.Services;
using Modelos.Entidades;
using System.Windows;
using System.Windows.Input;
#endregion

namespace WPFView.Privado
{
    public partial class AtividadeDetalhes : Window
    {

        #region--Atributos--
        private Atividade atividade;
        private AtividadeService atividadeService;
        private bool IsConcluida;
        #endregion

        #region--Construtor--
        public AtividadeDetalhes(Atividade atividade, bool IsConcluida)
        {
            InitializeComponent();
            this.atividade = atividade;
            atividadeService = new AtividadeService();
            this.IsConcluida = IsConcluida;
            Page_Load();
        }
        #endregion

        #region --Page_Load--
        private void Page_Load()
        {
            TextBlockTitulo.Text = atividade.Titulo;
            ListItemDescricao.Text += atividade.Descricao;

            var calculo = new AtividadeService().CalcularMinutosGastos(atividade.ID);
            ListItemMinutos.Text += calculo is 0 ? "Menos que um minuto." : ($"{ calculo } Minuto(s). ");

            calculo = new AtividadeService().CalcularHorasGastas(atividade.ID);
            ListItemHoras.Text += calculo is 0 ? "Menos que uma hora." : ($"{ calculo } Hora(s). ");

            calculo = new AtividadeService().CalcularDiasGastos(atividade.ID);
            ListItemDias.Text += calculo is 0 ? "Menos que um dia." : ($"{ calculo } Dia(s). ");

            if(IsConcluida)           
                TrabalharNaAtividade.Visibility =  FinalizarTarefa.Visibility =  Visibility.Collapsed;
            
        }
        #endregion

        #region--TrabalharNaAtividade-
        private void TrabalharNaAtividade_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new Trabalhando(atividade).Show();
            Close();
        }
        #endregion

        #region--FinalizarTarefaClick--
        private void FinalizarTarefa_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            atividadeService.Atualizar(atividade.ID, Atividade.AtividadeStatus.Concluida);
            new TelaInicial().Show();
            Close();
        }
        #endregion

        #region--ButtonVoltar--
        private void ButtonVoltar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!IsConcluida)
                new TelaInicial().Show();
            else
                new TodasAtividades().Show();
            Close();
        }
        #endregion

    }
}
