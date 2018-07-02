#region --Using--
using BespokeFusion;
using BusinessLogic.Services;
using Modelos.Entidades;
using System;
using System.Windows;
using System.Windows.Input;
#endregion

namespace WPFView.Privado
{
    public partial class NovaAtividade : Window
    {
        #region --Construtor
        public NovaAtividade()
        {
            InitializeComponent();
        }
        #endregion

        #region--ButtonCadastrarAtividade--
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
        #endregion

        #region--ButtonCadastrarAtividade--
        private void ButtonVoltar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new TelaInicial().Show();
            Close();
        }
        #endregion

    }
}
