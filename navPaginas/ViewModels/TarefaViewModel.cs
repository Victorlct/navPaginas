using navPaginas.Models;
using System.ComponentModel.DataAnnotations;

namespace navPaginas.ViewModels
{
    public class TarefaViewModel
    {
        public int TarefaID { get; }
        [Required(ErrorMessage = "Por favor preencha o titulo da tarefa")]
        [StringLength(20, ErrorMessage = "{0} deve conter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string Titulo { get; }
        [Required(ErrorMessage = "Por favor preencha a descrição da tarefa")]
        [StringLength(50, ErrorMessage = "{0} deve conter entre {2} e {1} caracteres.", MinimumLength = 6)]
        public string Descricao { get; }
        public bool? Ativa { get; }
        public DateTime? Criacao { get; }
        public DateTime? Termino { get; }
        public DateTime Entrega { get; set; }
        public List<object> Eventos { get; set; }

        public TarefaViewModel(Tarefa tarefa)
        {
            TarefaID = tarefa.Id;
            Titulo = tarefa.Titulo;
            Descricao = tarefa.Descricao;
            Ativa = tarefa.Ativa;
            Criacao = tarefa.Criacao;
            Termino = tarefa.Termino;
            Entrega = tarefa.Entrega;
        }
        public TarefaViewModel(List<Tarefa> tarefas)
        {
            Eventos = new List<object>();
            foreach (var tarefa in tarefas)
            {
                var evento = new
                {
                    id = tarefa.Id,
                    title = tarefa.Titulo,
                    //start = tarefa.Entrega.ToString("yyyy-MM-ddTHH:mm:ss")
                    start = tarefa.Entrega.ToString("yyyy-MM-dd")
                };
                Eventos.Add(evento);
            }
        }
    }
}
