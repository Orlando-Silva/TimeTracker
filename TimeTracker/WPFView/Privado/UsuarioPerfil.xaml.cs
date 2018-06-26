#region --Using--
using Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
#endregion

namespace WPFView.Privado
{
    /// <summary>
    /// Interaction logic for UsuarioPerfil.xaml
    /// </summary>
    public partial class UsuarioPerfil : Window
    {
        public UsuarioPerfil()
        {
            InitializeComponent();
            var usuario = Application.Current.Properties["_user"] as Usuario;
            LabelLogin.Content = usuario.Login;
            LabelNome.Content = usuario.Nome;
        }
    }
}
