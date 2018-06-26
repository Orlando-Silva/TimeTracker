using Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
#region --Using--
using System.Windows;

#endregion

namespace WPFView.Privado
{
    public partial class TelaInicial : Window
    {
        #region --Atributos--
        public TelaInicial()
        {
            InitializeComponent();
            var usuario = Application.Current.Properties["_user"] as Usuario;
            labelUsuario.Content = $"Olá { usuario.Nome }!";
        }
        #endregion
    }
}
