using Microsoft.EntityFrameworkCore;

namespace TimeManager.DATA.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<ActTask> ActTasks { get; set; }

    }
}
