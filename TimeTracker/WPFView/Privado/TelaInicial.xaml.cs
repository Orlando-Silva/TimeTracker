
#region --Using--
using System.Windows;
using Modelos.Entidades;
using System;
using System.Collections.Generic;
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
            labelUsuario.Content = $"Olá { usuario.Nome }!";
        }
        #endregion

        #region --Eventos--
        private void PackIcon_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new UsuarioPerfil().Show();
            this.Close();
        }
        #endregion
    }
}
