using Microsoft.EntityFrameworkCore;

namespace TimeManager.DATA.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
