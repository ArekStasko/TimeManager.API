using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.API.Data;

namespace TimeManager.API.Tests
{
    public class TestTMDbContext : IDataContext
    {
        public TestTMDbContext()
        {
            this.Activities = new TestActivityDbSet();
            this.Categories = new TestCategoryDbSet();
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<vwActivityCategory> vwActivityCategory { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<vwCategory> vwCategories { get; set; }


    }
}
