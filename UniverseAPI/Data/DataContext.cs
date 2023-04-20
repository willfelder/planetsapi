global using Microsoft.EntityFrameworkCore;

namespace UniverseAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=planetsdb;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<Planets> Planets { get; set; }
    }
}
