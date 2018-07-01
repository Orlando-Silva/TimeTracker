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
    public partial class NovaAtividade : Window
    {
        public NovaAtividade()
        {
            InitializeComponent();
        }

        private void ButtonCadastrarAtividade_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var usuario = Application.Current.Properties["_user"] as Usuario;
                new AtividadeService().Inserir(TextBoxTitulo.Text, TextBoxDescricao.Text, usuario.ID);
                new TelaInicial().Show();
                Close();
            }
            catch(Exception exception)
            {
                MaterialMessageBox.Show(exception.Message, "Erro");
            }
        }

    }
}
