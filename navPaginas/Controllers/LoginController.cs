using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using navPaginas.Models;
using System.Security.Claims;
using navPaginas.ViewModels;
using navPaginas.Helpers;
using System.Runtime.CompilerServices;
using navPaginas.Interfaces;
using navPaginas.Services;
using Newtonsoft.Json;

namespace navPaginas.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            TempData["ErrorMessage"] = "Você não tem permissão para acessar a página solicitada, faça login para continuar.";
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Index(Login tentativaLogin)
        {
            var obj = _loginService.ValidarLogin(tentativaLogin);
            if (obj == null)
            {
                ModelState.AddModelError("", "Usuário ou senha incorretos");
                return View("Index");
            }
            else
            {
                var objJson = JsonConvert.SerializeObject(obj);
                var claims = new List<Claim>();
                var claim = new Claim("LoginObject", objJson);
                claims.Add(claim);
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties { };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                HttpContext.Session.SetInt32("LoginId", obj.Id);
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Login novoUser)
        {
            if (_loginService.UsuarioExiste(novoUser))
            {
                ViewBag.Message = "Usuário já existe.";
                return View();
            }
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Usuário criado com sucesso!";
                _loginService.CriarUsuario(novoUser);
                return View("Index");
            }
            return View(novoUser);
        }

        public IActionResult RegistroConcluido()
        {
            return View();
        }
    }
}
