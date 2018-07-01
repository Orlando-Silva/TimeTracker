using BespokeFusion;
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
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFView.Privado
{
    public partial class AtividadeDetalhes : Window
    {

        private Atividade atividade;

        public AtividadeDetalhes(Atividade atividade)
        {
            InitializeComponent();
            this.atividade = atividade;
            TextBlockTitulo.Text = atividade.Titulo;
            ListItemDescricao.Content = atividade.Descricao;
            ListItemHoras.Content = $@"Tempo gasto nesta atividade:\n
                                        Em Dias: { new AtividadeService().CalcularDiasGastos(atividade.ID) }.
                                        Em Horas: { new AtividadeService().CalcularHorasGastas(atividade.ID) }.
                                        Em Minutos: { new AtividadeService().CalcularMinutosGastos(atividade.ID) }.";

        }

        private void TrabalharNaAtividade_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new Trabalhando(atividade).Show();
            Close();
        }

        private void FinalizarTarefa_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new AtividadeService().Atualizar(atividade.ID, Modelos.Entidades.Atividade.AtividadeStatus.Concluida);
            new TelaInicial().Show();
            Close();
        }

        private void Voltar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new TelaInicial().Show();
            Close();
        }
    }
}
