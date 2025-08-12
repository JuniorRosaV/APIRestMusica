using Microsoft.EntityFrameworkCore;
using MusicaProjeto.Modelos.Modelo;

namespace Musica_Projeto.Banco
{
    public class MusicaProjectContext: DbContext
    {
        public DbSet<Artistas> Artistas { get; set; }
        public DbSet<Musicas> Musicas { get; set; }
        public DbSet<Generos> Generos { get; set; }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies(); 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musicas>()
                .HasMany(c => c.Generos)
                .WithMany(c => c.Musicas);
        }
    }
}
