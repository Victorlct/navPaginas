using navPaginas.Interfaces;
using navPaginas.Models;
using Newtonsoft.Json;

namespace navPaginas.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        public void CriarTarefa(Tarefa novaTarefa, int loginID)
        {
            if (novaTarefa.Entrega == DateTime.MinValue)
            {
                novaTarefa.Entrega = DateTime.Today.AddDays(1);
            }
            novaTarefa.LoginId = loginID;
            novaTarefa.Criacao = DateTime.Now;
            novaTarefa.Ativa = true;
            _tarefaRepository.AddTarefa(novaTarefa);
        }
        public void RemoverTarefa(int id)
        {
            _tarefaRepository.RemoveTarefa(id);
        }
        public void ConcluirTarefa(int id)
        {
            var _tarefa = _tarefaRepository.TarefaById(id);
            _tarefa.Ativa = false;
            _tarefa.Termino = DateTime.Now;
            _tarefaRepository.AtualizarTarefa(_tarefa);
        }
        public void EditarTarefa(Tarefa novaTarefa)
        {
            var tarefa = _tarefaRepository.TarefaById(novaTarefa.Id);
            if (tarefa != null)
            {
                tarefa.Titulo = novaTarefa.Titulo;
                tarefa.Descricao = novaTarefa.Descricao;
                tarefa.Entrega = novaTarefa.Entrega;
            }
            _tarefaRepository.AtualizarTarefa(tarefa);
        }

        public Tarefa DetalhesTarefa(int id)
        {
            var tarefa = _tarefaRepository.TarefaById(id);
            if(tarefa != null)
            {
                return tarefa;
            }
            return null;
        }
        public IEnumerable<Tarefa> getTodasTarefas(int idLogin)
        {
            IEnumerable<Tarefa> todasTarefas = _tarefaRepository.TodasTarefas.Where(t => t.LoginId.Equals(idLogin)).OrderBy(t => t.Entrega); ;
            return todasTarefas;
        }
        public IEnumerable<Tarefa> getTodasTarefasDesativadas(int idLogin)
        {
            IEnumerable<Tarefa> todasTarefas = _tarefaRepository.TodasTarefas.Where(t => t.LoginId.Equals(idLogin) && t.Ativa==false).OrderBy(t => t.Entrega); ;
            return todasTarefas;
        }
        public IEnumerable<Tarefa> getTodasTarefasAtivas(int idLogin)
        {
            IEnumerable<Tarefa> todasTarefas = _tarefaRepository.TodasTarefas.Where(t => t.LoginId.Equals(idLogin) && t.Ativa == true).OrderBy(t => t.Entrega); ;
            return todasTarefas;
        }
    }
}
