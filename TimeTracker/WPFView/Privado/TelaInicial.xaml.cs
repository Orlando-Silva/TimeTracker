#region --Using--
using System.Windows;
using Modelos.Entidades;
using System.Collections.Generic;
using BusinessLogic.Services;
using System.Linq;
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

            if (atividades.Any())
                DataGridAtividades.ItemsSource = atividades;
            else
            {
                DataGridAtividades.Visibility = Visibility.Hidden;
                CardAviso.Visibility = Visibility.Visible;
            }

            labelUsuario.Text = $"Olá { usuario.Nome }!";
        }
        #endregion 

        #region --ButtonLogout--
        private void ButtonLogout_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Application.Current.Properties["_user"] = null;
            new Login().Show();
            Close();
        }
        #endregion

        #region --Botões do Topo--
        private void AdicionarAtividade_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new NovaAtividade().Show();
            Close();
        }

        private void VerTodasAtividades_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new TodasAtividades().Show();
            Close();
        }
        #endregion

        #region --DataGridRowClick--
        private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var atividade = DataGridAtividades.SelectedItem as Atividade;
            new AtividadeDetalhes(atividade).Show();
            Close();
        }
        #endregion
    }
}
