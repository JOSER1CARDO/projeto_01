using Microsoft.EntityFrameworkCore;
using Projeto02.Models;

namespace Projeto02.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Método que aplica automaticamente todas as configurações de entidade
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            modelBuilder.Entity<Categoria>();

        }




    }
}
