using Microsoft.EntityFrameworkCore;
using navPaginas.Models;

namespace navPaginas.Database
{
    public class navPaginasDbContext : DbContext
    {

        public navPaginasDbContext(DbContextOptions<navPaginasDbContext> options) : base(options) { }

        public DbSet<Login> Login { get; set; }

        public DbSet<Tarefa> Tarefa { get; set; }

    }
}
