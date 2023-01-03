using Microsoft.EntityFrameworkCore;

namespace TimeManager.DATA.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public virtual DbSet<Task_> Tasks { get; set; }
        public virtual DbSet<TaskSet> TaskSets { get; set; }
    }
}
