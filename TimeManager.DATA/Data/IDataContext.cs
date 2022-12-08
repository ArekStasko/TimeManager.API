using Microsoft.EntityFrameworkCore;

namespace TimeManager.DATA.Data
{
    public interface IDataContext 
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Task> Categories { get; set; }
    }
}
