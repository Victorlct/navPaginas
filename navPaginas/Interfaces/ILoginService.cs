using navPaginas.Models;
using navPaginas.Services;

namespace navPaginas.Interfaces
{
    public interface ILoginService
    {
        public Login ValidarLogin(Login tentativaLogin);
        void CriarUsuario(Login novoUser);
        public bool UsuarioExiste(Login user);
        void SetSenhaHash(Login login);
    }
}
