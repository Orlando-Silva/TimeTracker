#region --Using--
using BespokeFusion;
using BusinessLogic.Services;
using System;
using System.Windows;
#endregion

namespace WPFView.Publico
{
    public partial class NovoUsuario : Window
    {

        #region --Atributos--
        private readonly UsuarioService usuarioService;
        #endregion

        #region --Construtor--
        public NovoUsuario()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
        }
        #endregion

        #region --Eventos Click--
        private void ButtonCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if(IsValid())
            {
                if(SenhasMatch())
                {
                    try
                    {
                        usuarioService.Inserir(TextBoxNome.Text, TextBoxLogin.Text, TextBoxSenha.Password);
                        new Login("Insira seu novo login").Show();
                        this.Close();

                    }
                    catch(Exception erro)
                    {
                        MaterialMessageBox.Show(erro.Message, "Erro");
                    }
                }
                else
                {
                    MaterialMessageBox.Show("Os campos 'Senha' e 'Confirmar senha' não batem!", "Erro");
                }
            }
            else
            {
                MaterialMessageBox.Show("Para prosseguir, preencha todos os campos!", "Erro");
            }
        }
        #endregion

        #region --Métodos--
        private bool IsValid() => !String.IsNullOrWhiteSpace(TextBoxLogin.Text) && !String.IsNullOrWhiteSpace(TextBoxNome.Text)
                               && !String.IsNullOrWhiteSpace(TextBoxSenha.Password) && !String.IsNullOrWhiteSpace(TextBoxConfirmarSenha.Password);
        private bool SenhasMatch() => TextBoxSenha.Password.ToString() == TextBoxConfirmarSenha.Password.ToString();
        #endregion
    }
}
