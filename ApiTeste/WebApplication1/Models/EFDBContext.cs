using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class EFDBContext : DbContext
    {
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
    }
}
