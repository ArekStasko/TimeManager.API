using Microsoft.EntityFrameworkCore;

namespace TimeManager.API.Data
{
    public interface IDataContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<vwActivityCategory> vwActivityCategory { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<vwCategory> vwCategories { get; set; }
    }
}
