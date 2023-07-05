using navPaginas.Database;
using navPaginas.Models;

namespace navPaginas.Interfaces
{
    public interface ITarefaService
    {
        void CriarTarefa(Tarefa novaTarefa, int loginID);
        void RemoverTarefa(int id);
        void ConcluirTarefa(int id);
        Tarefa DetalhesTarefa(int id);
        void EditarTarefa(Tarefa novaTarefa);
        IEnumerable<Tarefa> getTodasTarefas(int loginID);
        IEnumerable<Tarefa> getTodasTarefasDesativadas(int idLogin);
        IEnumerable<Tarefa> getTodasTarefasAtivas(int idLogin);
    }
}
