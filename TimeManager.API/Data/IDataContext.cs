using Microsoft.EntityFrameworkCore;

namespace TimeManager.API.Data
{
    public interface IDataContext 
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
