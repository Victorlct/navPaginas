using System.IO.Pipelines;
using navPaginas.Models;

namespace navPaginas.Interfaces
{
    public interface ITarefaRepository
    {
        IEnumerable<Tarefa> TodasTarefas { get; }
        Tarefa TarefaById(int _id);
        Tarefa TarefaByTitulo(string _titulo);
        void AddTarefa(Tarefa novaTarefa);
        void RemoveTarefa(int id);
        void AtualizarTarefa(Tarefa tarefa);
    }
}
