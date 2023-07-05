using Microsoft.EntityFrameworkCore;
using navPaginas.Helpers;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;
using System.Net.Mail;

namespace navPaginas.Models
{
    [Index(nameof(Usuario), IsUnique = true)]
    public class Login
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Por favor preencha o campo Usuario")]
        [StringLength(15, ErrorMessage = "{0} deve conter entre {2} e {1} caracteres.", MinimumLength = 6)]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Por favor preencha o campo Senha")]
        [StringLength(50, ErrorMessage = "{0} deve conter entre {2} e {1} caracteres.", MinimumLength = 4)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Por favor preencha o campo E-mail")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
    ErrorMessage = "O e-mail é inválido")]
        public string Email { get; set; }
    }
}
