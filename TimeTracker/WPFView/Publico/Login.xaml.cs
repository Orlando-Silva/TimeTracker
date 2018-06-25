#region --Using--
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
using WPFView.Publico;
#endregion

namespace WPFView
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        #region --Construtor--
        public Login()
        {
            InitializeComponent();
            LabelCriarLogin.Content = "Não possuo login";
        }
        #endregion

        #region --Eventos--
        private void LabelCriarLogin_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new NovoUsuario().Show();
            this.Close();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

    }
}
