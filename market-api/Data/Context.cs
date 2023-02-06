using market_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace market_api.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options): base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}