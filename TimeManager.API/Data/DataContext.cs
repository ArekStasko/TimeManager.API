using Microsoft.EntityFrameworkCore;

namespace TimeManager.API.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<vwActivityCategory> vwActivityCategory { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<vwCategory> vwCategories { get; set; }
    }
}
