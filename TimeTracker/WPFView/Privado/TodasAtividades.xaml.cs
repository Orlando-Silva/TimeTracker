#region --Using--
using System.Windows;
using Modelos.Entidades;
using System.Collections.Generic;
using BusinessLogic.Services;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
#endregion

namespace WPFView.Privado
{
    public partial class TodasAtividades : Window
    {
        #region --Construtor--
        public TodasAtividades()
        {
            InitializeComponent();
            var usuario = Application.Current.Properties["_user"] as Usuario;
            var atividades = new AtividadeService().CarregaAtividadePorUsuario(usuario.ID) as List<Atividade>;
            DataGridAtividades.ItemsSource = atividades;
        }
        #endregion

        #region --DataGridRowClick--
        private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var atividade = DataGridAtividades.SelectedItem as Atividade;
            new AtividadeDetalhes(atividade, true).Show();
            Close();
        }
        #endregion

        #region--ButtonVoltar--
        private void ButtonVoltar_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new TelaInicial().Show();
            Close();
        }
        #endregion
    }
}
