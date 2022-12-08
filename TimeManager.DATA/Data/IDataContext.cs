using Microsoft.EntityFrameworkCore;

namespace TimeManager.DATA.Data
{
    public interface IDataContext 
    {
        public DbSet<ActTask> ActTasks { get; set; }
    }
}
