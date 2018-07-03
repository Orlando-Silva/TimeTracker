#region --Using--
using BusinessLogic.Services;
using Modelos.Entidades;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
#endregion

namespace WPFView.Privado
{
    public partial class Trabalhando : Window
    {

        #region --Atributos--
        private DateTime inicio;
        private Atividade atividade;
        #endregion

        #region --Construtor--
        public Trabalhando(Atividade atividade)
        {
            this.atividade = atividade;
            InitializeComponent();
        }
        #endregion

        #region --ButtonFinalizarPeriodo--
        private void FinalizarPeriodo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new PeriodoService().Inserir(inicio, DateTime.UtcNow, atividade.ID);
            new TelaInicial().Show();
            Close();
        }
        #endregion

        #region --TrabalharNaAtividade--
        private void TrabalharNaAtividade_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            inicio = DateTime.UtcNow;
            TrocarButtons();
            SetDispatcherTimer();
        }
        #endregion

        #region --DispatchTimer_Tick--
        private void DispatcherTimer_Tick(object sender, EventArgs e) => FinalizarPeriodo.Content = DateTime.Now.ToString("HH:mm:ss");
        #endregion

        #region --DispatchTimerSet--
        private void SetDispatcherTimer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        #endregion

        #region--ButtonVoltar--
        private void ButtonVoltar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new AtividadeDetalhes(atividade,false).Show();
            Close();
        }
        #endregion

        #region --Outros--
        private void TrocarButtons()
        {
            TrabalharNaAtividade.Visibility = Visibility.Collapsed;
            FinalizarPeriodo.Visibility = Visibility.Visible;
        }
        #endregion
    }
}
