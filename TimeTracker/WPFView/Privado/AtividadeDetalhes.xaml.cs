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
        public AtividadeDetalhes(Atividade atividade)
        {
            InitializeComponent();
            TextBlockTitulo.Text = atividade.Titulo;
            ListItemDescricao.Content = atividade.Descricao;
        }

        private void TrabalharNaAtividade_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void FinalizarTarefa_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Voltar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
