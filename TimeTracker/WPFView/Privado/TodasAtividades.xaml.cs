#region --Using--
using System.Windows;
using Modelos.Entidades;
using System.Collections.Generic;
using BusinessLogic.Services;
using System.Windows.Controls;
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
    }
}
