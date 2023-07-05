using System.IO.Pipelines;
using navPaginas.Models;

namespace navPaginas.ViewModels
{
    public class ConsultasViewModel
    {
        public IEnumerable<Login> TodosLogins { get; }

        public ConsultasViewModel(IEnumerable<Login> todosLogins)
        {
            TodosLogins = todosLogins;
        }
    }
}
