using Microsoft.AspNetCore.Mvc;
using navPaginas.Interfaces;
using navPaginas.Models;
using Microsoft.IdentityModel.Tokens;
using navPaginas.Helpers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using navPaginas.ViewModels;
using System.Runtime.CompilerServices;
using navPaginas.Services;
using navPaginas.Database;

namespace navPaginas.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public Login ValidarLogin(Login tentativaLogin)
        {
            SetSenhaHash(tentativaLogin);
            if (tentativaLogin.Usuario == null || tentativaLogin.Senha == null)
            {
                return null;
            }
                var obj = _loginRepository.ValidarLogin(tentativaLogin.Usuario, tentativaLogin.Senha);
                if (obj == null)
                {
                    return null;
                }
                else
                {
                    return obj;
                }
        }
        

        public void CriarUsuario(Login novoUser)
        {
            SetSenhaHash(novoUser);
            try
            {
                _loginRepository.CriarUsuario(novoUser);
            }
            catch
            {

            }
        }
        public bool UsuarioExiste(Login novoUser)
        {
            var userExiste = _loginRepository.LoginByUsuario(novoUser.Usuario);
            if (novoUser.Usuario.IsNullOrEmpty())
            {
                return true;
            }
            if (userExiste != null)
            {
                return true;
            }
            return false;
        }
        public void SetSenhaHash(Login login)
        {
            if (login.Senha.IsNullOrEmpty())
            {
                login.Senha = login.Senha;
            }
            else 
            {
                login.Senha = login.Senha.GerarHash();
            }        
        }
    }
}
