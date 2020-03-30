using Microsoft.EntityFrameworkCore;
using SistemaFotos.Web.Models;

namespace SistemaFotos.Web.Dados
{
    public class FotosContext : DbContext
    {
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Galeria> Galerias { get; set; }
        public FotosContext(DbContextOptions<FotosContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Imagem>().HasKey(e => e.Id);
            modelBuilder.Entity<Imagem>().HasOne(e => e.Galeria);

            modelBuilder.Entity<Galeria>().HasKey(e => e.Id);
        }
    }
}