using Microsoft.EntityFrameworkCore;

namespace TimeManager.DATA.Data
{
    public interface IDataContext 
    {
        public DbSet<Task_> ActTasks { get; set; }
    }
}
