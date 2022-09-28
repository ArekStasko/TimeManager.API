using Microsoft.EntityFrameworkCore;

namespace TimeManager.API.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<vwActivityCategory> vwActivityCategory { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<vwCategory> vwCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vwActivityCategory>(ac =>
            {
                ac.HasNoKey();
                ac.ToView("vwActivityCategory");
            });

            modelBuilder.Entity<vwCategory>(c =>
            {
                c.HasNoKey();
                c.ToView("vwCategories");
            });
        }
    }
}
