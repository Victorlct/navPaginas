using Microsoft.AspNetCore.Mvc;
using navPaginas.Interfaces;
using navPaginas.ViewModels;

namespace navPaginas.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly ILoginRepository _loginRepository;

        public ConsultasController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public IActionResult ListarTodosUsuarios()
        {
            var todosLogins = _loginRepository.TodosLogins;
            var todosLoginsViewModel = new ConsultasViewModel(todosLogins);

            return View(todosLoginsViewModel);
        }

        public IActionResult ListarUsuario(int id)
        {
                var todosLogins = _loginRepository.LoginById(id);
                if (todosLogins == null)
                    return NotFound();

                var todosLoginsViewModel = new ConsultaIdViewModel(todosLogins);
                return View(todosLoginsViewModel);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
