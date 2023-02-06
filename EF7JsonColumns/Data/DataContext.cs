using Microsoft.EntityFrameworkCore;

namespace EF7JsonColumns.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=HAZEM;Database=superherotestdb;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperHero>().OwnsOne(sh=>sh.Details, navigationBuilder=>
            {
                navigationBuilder.ToJson();
            });
        }

        public DbSet<SuperHero> Heroes { get; set; }
    }
}
