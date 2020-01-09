using Microsoft.EntityFrameworkCore;
using SistemaFotos.Web.Models;

namespace SistemaFotos.Web.Dados
{
    public class FotosContext : DbContext
    {
        public DbSet<Imagem> Imagens { get; set; }
        public FotosContext(DbContextOptions<FotosContext> options) : base(options)
        {
        }
    }
}