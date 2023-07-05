using System.IO.Pipelines;
using navPaginas.Models;

namespace navPaginas.ViewModels
{
    public class TodasTarefasViewModel
    {
        public IEnumerable<Tarefa> TodasTarefas { get; }

        public TodasTarefasViewModel(IEnumerable<Tarefa> todasTarefas)
        {
            TodasTarefas = todasTarefas;
        }
    }
}
