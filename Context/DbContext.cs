using BasarsoftInternship.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasarsoftInternship.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Point> Points { get; set; }

      
    }
}
