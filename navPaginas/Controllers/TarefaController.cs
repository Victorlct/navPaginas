using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using navPaginas.Interfaces;
using navPaginas.Models;
using navPaginas.ViewModels;
using navPaginas.Services;
using navPaginas.Database;
using Newtonsoft.Json;

namespace navPaginas.Controllers
{
    [Authorize]
    public class TarefaController : Controller
    {
        private readonly ITarefaService _tarefaService;
        private Login ObterLoginAtual()
        {
            var objLoginClaim = User.Claims.FirstOrDefault(c => c.Type == "LoginObject");
            var objLogin = objLoginClaim != null ? JsonConvert.DeserializeObject<Login>(objLoginClaim.Value) : null;
            return objLogin;
        }
        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }
        public IActionResult CriarTarefa()
        {
            return View();
        }
        public IActionResult TarefaRegistrada()
        {
            return View();
        }

        public IActionResult ConcluirTarefa(int id)
        {
            try
            {
                _tarefaService.ConcluirTarefa(id);
            }
            catch
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult CriarTarefa(Tarefa novaTarefa)
        {
            var objLogin = ObterLoginAtual();
            try
            {
                _tarefaService.CriarTarefa(novaTarefa, objLogin.Id);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View(novaTarefa);
            }
        }
        public IActionResult RemoverTarefa(int id)
        {
            try
            {
                _tarefaService.RemoverTarefa(id);
            }
            catch
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Details(int id)
        {
            var tarefa = _tarefaService.DetalhesTarefa(id);
            if (tarefa == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var objLogin = ObterLoginAtual();
            if (tarefa.LoginId != objLogin.Id)
            {
                return RedirectToAction("Index", "Home");
            }

            var tarefaViewModel = new TarefaViewModel(tarefa);
            return View(tarefaViewModel);
        }

        public IActionResult DetailsModal(int id)
        {
            var tarefa = _tarefaService.DetalhesTarefa(id);
            var tarefaViewModel = new TarefaViewModel(tarefa);
            return PartialView("_tarefaDetails", tarefaViewModel);
        }
        public IActionResult EditarTarefa(int id)
        {
            var tarefa = _tarefaService.DetalhesTarefa(id);
            var objLogin = ObterLoginAtual();
            if (tarefa.LoginId != objLogin.Id)
            {
                return RedirectToAction("Index", "Home");
            }
            var tarefaViewModel = new TarefaViewModel(tarefa);
            return View(tarefaViewModel);
        }
        [HttpPost]
        public IActionResult EditarTarefa(Tarefa novaTarefa)
        {
            _tarefaService.EditarTarefa(novaTarefa);            
            return RedirectToAction("Index", "Home");
        }

    }
}
