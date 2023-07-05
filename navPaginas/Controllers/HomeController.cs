using Microsoft.AspNetCore.Mvc;
using navPaginas.Interfaces;
using navPaginas.Models;
using navPaginas.ViewModels;
using Newtonsoft.Json;
using System.Diagnostics;

namespace navPaginas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITarefaService _tarefaService;
        public HomeController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }
        private Login ObterLoginAtual()
        {
            var objLoginClaim = User.Claims.FirstOrDefault(c => c.Type == "LoginObject");
            var objLogin = objLoginClaim != null ? JsonConvert.DeserializeObject<Login>(objLoginClaim.Value) : null;
            return objLogin;
        }
        public IActionResult Index(string queryBusca)
        {
            var objLogin = ObterLoginAtual();
            if (User.Identity.IsAuthenticated)
            {
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return RedirectToAction("ListaTarefasParcial", new { queryBusca = queryBusca });
                }
                else
                {
                    var todasTarefas = _tarefaService.getTodasTarefasAtivas(objLogin.Id);
                    var todasTarefasViewModel = new TodasTarefasViewModel(todasTarefas);
                    return View(todasTarefasViewModel);
                }
            }
            else
            {
                return View();
            }
        }
        public IActionResult Desativadas(string queryBusca)
        {
            var objLogin = ObterLoginAtual();
            if (User.Identity.IsAuthenticated)
            {
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return RedirectToAction("ListaTarefasParcial", new { queryBusca = queryBusca });
                }
                else
                {
                    var todasTarefas = _tarefaService.getTodasTarefasDesativadas(objLogin.Id);
                    var todasTarefasViewModel = new TodasTarefasViewModel(todasTarefas);
                    return View(todasTarefasViewModel);
                }
            }
            else
            {
                return View();
            }
        }
        public IActionResult ListaTarefasParcialAtivas(string queryBusca)
        {
            var objLogin = ObterLoginAtual();

            IEnumerable<Tarefa> todasTarefas;

            if (!string.IsNullOrEmpty(queryBusca))
            {
                todasTarefas = _tarefaService.getTodasTarefasAtivas(objLogin.Id).Where(t => t.Titulo.Contains(queryBusca));
            }
            else
            {
                todasTarefas = _tarefaService.getTodasTarefasAtivas(objLogin.Id);
            }

            var todasTarefasViewModel = new TodasTarefasViewModel(todasTarefas);

            return PartialView("_ListaTarefas", todasTarefasViewModel);
        }
        public IActionResult ListaTarefasParcialDesativadas(string queryBusca)
        {
            var objLogin = ObterLoginAtual();

            IEnumerable<Tarefa> todasTarefas;

            if (!string.IsNullOrEmpty(queryBusca))
            {
                todasTarefas = _tarefaService.getTodasTarefasDesativadas(objLogin.Id).Where(t => t.Titulo.Contains(queryBusca));
            }
            else
            {
                todasTarefas = _tarefaService.getTodasTarefasDesativadas(objLogin.Id);
            }

            var todasTarefasViewModel = new TodasTarefasViewModel(todasTarefas);

            return PartialView("_ListaTarefas", todasTarefasViewModel);
        }

        public IActionResult Calendario()
        {
            var objLogin = ObterLoginAtual();
            if(objLogin == null)
            {
                return RedirectToAction("CriarTarefa", "Tarefa");
            }
            var todasTarefas = _tarefaService.getTodasTarefasAtivas(objLogin.Id);
            var tarefaViewModel = new TarefaViewModel(todasTarefas.ToList());
            return View(tarefaViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}