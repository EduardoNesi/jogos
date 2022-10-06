using Microsoft.EntityFrameworkCore;

namespace Prova.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<CategoriadeJogo> Categorias { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
    }
}