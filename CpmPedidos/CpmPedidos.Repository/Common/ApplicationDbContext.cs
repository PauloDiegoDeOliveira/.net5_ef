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

        public ApplicationDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        // 4 ApplicationDbContext 
        // Detecção automática de alterações do rastreador de alterações habilitado
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}