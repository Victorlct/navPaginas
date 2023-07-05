using System.IO.Pipelines;
using navPaginas.Models;

namespace navPaginas.Interfaces
{
    public interface ILoginRepository
    {
        IEnumerable<Login> TodosLogins { get; }
        Login LoginById(int _id);
        Login LoginByUsuario(string user);
        public string GetSenha(string user);
        void CriarUsuario(Login novoUser);
        Login ValidarLogin(string user, string senha);
    }
}
