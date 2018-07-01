#region --Using--
using BusinessLogic.Services.Interfaces;
using Controlador.BaseManager;
using Helpers;
using Modelos.Entidades;
using Modelos.Enums;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
#endregion

namespace BusinessLogic.Services
{
    public class UsuarioService : IUsuarioService
    {
        #region --Atributos--
        private readonly UsuarioController usuarioController;
        #endregion

        #region --Construtor--
        public UsuarioService()
        {
            usuarioController = new UsuarioController();
        }
        #endregion

        #region --IUsuarioService--

        #region --Carregar--
        public Usuario Carrega(int ID) => usuarioController.CarregaComPredicato(_ => _.ID == ID);

        public Usuario CarregaPorLogin(string login) => usuarioController.CarregaComPredicato(_ => _.Login == login);
        #endregion

        #region --Inserir--
        public void Inserir(string nome, string login, string senha)
        {
            Validar(nome, login, senha);
            usuarioController.Inserir( Preparar(nome, login, senha));
        }

        public void Validar(string nome, string login, string senha)
        {

            if (String.IsNullOrWhiteSpace(nome) || String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(senha))
                throw new Exception("Preencha todos os campos.");

            if (usuarioController.LoginExiste(login))
                throw new Exception("Este login já existe em nossa base de dados.");

            if (senha.Length < 6) 
                throw new Exception("A senha deve conter mais de 6 caracteres");           
        }

        public Usuario Preparar(string nome, string login, string senha)
        {
            return new Usuario()
            {
                Nome = nome,
                Login = login,
                Senha = Seguranca.GerarHashSHA512(senha),
                Status = Genericos.Status.Ativo,
                Criado = DateTime.UtcNow
            };         
        }
        #endregion

        #region --Atualizar--
        public void Atualizar(int ID, Genericos.Status status)
        {
            var usuario = usuarioController.Carregar(ID) as Usuario;
            usuario.Status = status;
            usuarioController.Atualizar(usuario);
        }

        public void Atualizar(int ID, string nome, string login, string senha)
        {
            Usuario usuario = usuarioController.Carregar(ID);

            if (!String.IsNullOrWhiteSpace(nome))
                usuario.Nome = nome;

            if (!String.IsNullOrWhiteSpace(login))
                usuario.Login = login;

            if (!String.IsNullOrWhiteSpace(senha))
                usuario.Senha = senha;

            usuarioController.Atualizar(usuario);
        }
        #endregion

        #region --Outros--
        public void Login(string login, string senha)
        {
            if ( String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(senha) )
                throw new Exception("Preencha todos os campos.");

            if( !usuarioController.LoginValido(login, Seguranca.GerarHashSHA512(senha)) )
                throw new Exception("Senha ou usuário errados.");

        }
        #endregion

        #endregion
    }
}
