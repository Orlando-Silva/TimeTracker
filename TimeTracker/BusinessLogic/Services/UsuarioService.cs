﻿#region --Using--
using BusinessLogic.Services.Interfaces;
using Controlador.BaseManager;
using Helpers;
using Modelos.Entidades;
using Modelos.Enums;
using System;
#endregion

namespace BusinessLogic.Services
{
    public class UsuarioService : IUsuarioService
    {
        #region --IUsuarioService--
        public void Inserir(string nome, string login, string senha)
        {
            Validar(nome, login, senha);        
            new UsuarioController().Inserir( Preparar(nome, login, senha));
        }

        public void Validar(string nome, string login, string senha)
        {
            if (String.IsNullOrWhiteSpace(nome) || String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(senha))
                throw new Exception("Preencha todos os campos.");

            if (new UsuarioController().LoginExiste(login))
                throw new Exception("Este login já existe em nossa base de dados.");

            if (senha.Length < 6) 
                throw new Exception("A senha deve conter mais de 6 caracteres");           
        }

        public Usuario Preparar(string nome, string login, string senha) => new Usuario(nome, login, Seguranca.GerarHashSHA512(senha));
        
        public void Login(string login, string senha)
        {
            if ( String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(senha) )
                throw new Exception("Preencha todos os campos.");

            if( !new UsuarioController().LoginValido(login, Seguranca.GerarHashSHA512(senha)) )
                throw new Exception("Senha ou usuário errados.");
        }

        public void Atualizar(int ID, Genericos.Status status)
        {
            var usuario = new UsuarioController().Carregar(ID);
            usuario.Atualizar(status);
            new UsuarioController().Atualizar(usuario);
        }
        
        public void Atualizar(int ID, string nome, string login, string senha)
        {
            Usuario usuario = new UsuarioController().Carregar(ID);
            usuario.Atualizar(nome, login, senha);
            new UsuarioController().Atualizar(usuario);           
        }          
        #endregion
    }
}