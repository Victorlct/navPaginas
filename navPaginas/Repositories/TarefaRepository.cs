using Microsoft.EntityFrameworkCore;
using navPaginas.Database;
using navPaginas.Interfaces;
using navPaginas.Models;
using System.Security.Claims;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace navPaginas.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly navPaginasDbContext _navPaginasDbContext;
        public TarefaRepository(navPaginasDbContext navPaginasDbContext)
        {
            _navPaginasDbContext = navPaginasDbContext;
        }
        public IEnumerable<Tarefa> TodasTarefas => _navPaginasDbContext.Tarefa.OrderBy(p => p.Id);

        public Tarefa TarefaById(int _id)
        {
            return _navPaginasDbContext.Tarefa.FirstOrDefault(i => i.Id == _id);
        }
        public Tarefa TarefaByTitulo(string _titulo)
        {
            return _navPaginasDbContext.Tarefa.FirstOrDefault(t => t.Titulo == _titulo);
        }
        public void AddTarefa(Tarefa novaTarefa)
        {
            _navPaginasDbContext.Tarefa.Add(novaTarefa);
            _navPaginasDbContext.SaveChanges();
        }
        public void RemoveTarefa(int id)
        {
            var tarefa = TarefaById(id);
            _navPaginasDbContext.Tarefa.Remove(tarefa);
            _navPaginasDbContext.SaveChanges();
        }
        public void AtualizarTarefa(Tarefa tarefa)
        {
            using (var dbContext = _navPaginasDbContext)
            {
                dbContext.Entry(tarefa).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
    }
}
