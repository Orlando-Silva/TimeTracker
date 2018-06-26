#region --Using--
using BespokeFusion;
using BusinessLogic.Services;
using Modelos.Entidades;
using System;
using System.Windows;
using System.Windows.Input;
using WPFView.Privado;
using WPFView.Publico;
#endregion

namespace WPFView
{
    public partial class Login : Window
    {

        #region --Atributos--
        private readonly UsuarioService usuarioService;
        #endregion

        #region --Construtor--
        public Login()
        {
            InitializeComponent();
            LabelCriarLogin.Content = "Não possuo login";
            usuarioService = new UsuarioService();
        }
        public Login(string mensagem)
        {
            InitializeComponent();
            LabelCriarLogin.Content = mensagem;
            usuarioService = new UsuarioService();
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
            try
            {
                usuarioService.Login(TextBoxLogin.Text, TextBoxSenha.Password);
                StoreInSession(usuarioService.CarregaPorLogin(TextBoxLogin.Text));
                new TelaInicial().Show();
                this.Close();
            }
            catch (Exception exception)
            {
                MaterialMessageBox.Show(exception.Message, "Erro");
            }
        }
        #endregion

        #region --Métodos--
        private void StoreInSession(Usuario user) => Application.Current.Properties["_user"] = user;       
        #endregion

    }
}
