using BusinessLogic.Services;
using MaterialDesignThemes.Wpf;
using Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPFView.Privado
{
    /// <summary>
    /// Lógica interna para Trabalhando.xaml
    /// </summary>
    public partial class Trabalhando : Window
    {

        private DateTime inicio;
        private Atividade atividade;
        private DateTime fim;

        public Trabalhando(Atividade atividade)
        {
            this.atividade = atividade;
            InitializeComponent();
        }

        private void FinalizarPeriodo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            fim = DateTime.UtcNow;
            new PeriodoService().Inserir(inicio, fim, atividade.ID);
            new TelaInicial().Show();
            Close();

        }

        private void TrabalharNaAtividade_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TrabalharNaAtividade.Visibility = Visibility.Collapsed;
            FinalizarPeriodo.Visibility = Visibility.Visible;
            inicio = DateTime.UtcNow;
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            FinalizarPeriodo.Content = DateTime.Now.ToString("HH:mm:ss");
        }

    }
}
