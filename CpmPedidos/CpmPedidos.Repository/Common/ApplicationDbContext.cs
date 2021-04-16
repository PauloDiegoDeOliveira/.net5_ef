using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;

namespace CpmPedidos.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cidade> Cidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cria o model, chamada da herança
            base.OnModelCreating(modelBuilder);

            //Carga de todo o mapeamento do conjunto. "assembly"
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        //Instanciar sem opções
        public ApplicationDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        // 4 ApplicationDbContext 
        // Instanciar com opções
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}