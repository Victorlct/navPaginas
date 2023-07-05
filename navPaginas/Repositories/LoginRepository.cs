using static navPaginas.Repositories.LoginRepository;
using System.IO.Pipelines;
using Microsoft.EntityFrameworkCore;
using navPaginas.Interfaces;
using navPaginas.Models;
using navPaginas.Database;

namespace navPaginas.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly navPaginasDbContext _navPaginasDbContext;

        public LoginRepository(navPaginasDbContext navPaginasDbContext)
        {
            _navPaginasDbContext = navPaginasDbContext;
        }
        public IEnumerable<Login> TodosLogins => _navPaginasDbContext.Login.OrderBy(p => p.Usuario);

        public Login LoginById(int _id)
        {
            return _navPaginasDbContext.Login.FirstOrDefault(i => i.Id == _id);
        }
        public Login ValidarLogin(string user, string senha)
        {
            return _navPaginasDbContext.Login.FirstOrDefault(u => u.Usuario == user && u.Senha == senha);
        }
        public Login LoginByUsuario(string user)
        {
            return _navPaginasDbContext.Login.FirstOrDefault(i => i.Usuario == user);
        }
        public string GetSenha(string user)
        {
            var login = _navPaginasDbContext.Login.FirstOrDefault(l => l.Usuario == user);
            return login?.Senha;
        }
        public void CriarUsuario(Login novoUser)
        {
            _navPaginasDbContext.Login.Add(novoUser);
            _navPaginasDbContext.SaveChanges();
        }
    }
}
