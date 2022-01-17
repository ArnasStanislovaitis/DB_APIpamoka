using Microsoft.EntityFrameworkCore;

namespace DB_ir_API.Models
{
    public class PavyzdinisDbContext: DbContext
    {
        public PavyzdinisDbContext(DbContextOptions<PavyzdinisDbContext> options) : base(options) { }

        public DbSet<Savininkas> Savininkai { get; set; }   
        public DbSet<Daiktas> Daiktai { get; set; }
        public DbSet<Automobilis> Automobiliai { get; set; }
    }
}
