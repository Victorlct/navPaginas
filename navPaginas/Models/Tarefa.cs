using navPaginas.Models;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;

namespace navPaginas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor preencha o titulo da tarefa")]
        [StringLength(20, ErrorMessage = "{0} deve conter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Por favor preencha a descrição da tarefa")]
        [StringLength(50, ErrorMessage = "{0} deve conter entre {2} e {1} caracteres.", MinimumLength = 6)]
        public string Descricao { get; set; }

        public bool? Ativa { get; set; }
        public DateTime? Criacao { get; set; }
        public DateTime? Termino { get; set; }
        public DateTime Entrega { get; set; }
        public int LoginId { get; set; }
        public Login Login { get; set; }
    }
}