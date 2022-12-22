using Microsoft.EntityFrameworkCore;

namespace TimeManager.DATA.Data
{
    public interface IDataContext 
    {
        public DbSet<Task_> Tasks { get; set; }
        public DbSet<TaskSet> TaskSets { get; set; }
    }
}
