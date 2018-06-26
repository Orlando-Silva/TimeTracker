#region --Using--
using BespokeFusion;
using BusinessLogic.Services;
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

namespace WPFView.Publico
{
    /// <summary>
    /// Interaction logic for NovoUsuario.xaml
    /// </summary>
    public partial class NovoUsuario : Window
    {
        #region --Construtor--
        public NovoUsuario()
        {
            InitializeComponent();
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
                        var usuarioService = new UsuarioService();
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
