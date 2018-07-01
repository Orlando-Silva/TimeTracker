#region --Using--
using System.Windows;
using Modelos.Entidades;
using System.Collections.Generic;
using BusinessLogic.Services;
using System.Windows.Controls;
#endregion

namespace WPFView.Privado
{
    public partial class TelaInicial : Window
    {
        #region --Construtor--
        public TelaInicial()
        {
            InitializeComponent();
            var usuario = Application.Current.Properties["_user"] as Usuario;
            var atividades = new AtividadeService().CarregaAtividadePorUsuarioStatus(usuario.ID, Atividade.AtividadeStatus.Pendente) as List<Atividade>;
            DataGridAtividades.ItemsSource = atividades;
            labelUsuario.Content = $"Olá { usuario.Nome }!";
        }
        #endregion 

        #region --PackIcon--
        private void PackIcon_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new NovaAtividade().Show();
            Close();
        }
        #endregion


        private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var atividade = DataGridAtividades.SelectedItem as Atividade;
            new AtividadeDetalhes(atividade).Show();
            Close();
        }
    }
}
