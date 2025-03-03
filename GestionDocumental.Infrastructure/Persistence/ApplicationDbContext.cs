using Microsoft.EntityFrameworkCore;
using GestionDocumental.Core.Entities;

namespace GestionDocumental.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        public DbSet<Documento> Documentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración adicional de modelos si es necesario
        }
    }
}