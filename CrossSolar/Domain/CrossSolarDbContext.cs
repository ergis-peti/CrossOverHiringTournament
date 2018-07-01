using Microsoft.EntityFrameworkCore;

namespace CrossSolar.Domain
{
    public class CrossSolarDbContext : DbContext
    {
        public CrossSolarDbContext()
        {
        }

        public CrossSolarDbContext(DbContextOptions<CrossSolarDbContext> options) : base(options)
        {
        }

        public DbSet<Panel> Panels { get; set; }

        public DbSet<OneHourElectricity> OneHourElectricity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}