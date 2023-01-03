using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Tests.Data
{
    public class MockDataContext : DbContext, IDataContext
    {
        public MockDataContext() { }
        public MockDataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Task_> Tasks { get; set; }
        public DbSet<TaskSet> TaskSets { get; set; }

        private List<Task_> GetTasks()
        {
            List<Task_> tasks = new List<Task_>()
            {
                new Task_
                {
                    Id = 1,
                    Name = "TestName",
                    Description  = "TestDescription",
                    Type = "TestType",
                    DateAdded = DateTime.Now,
                    DateCompleted = DateTime.Now,
                    Deadline = DateTime.Now,
                    Priority = 4,
                    UserId = 1
                },
                new Task_
                {
                    Id = 2,
                    Name = "TestName",
                    Description  = "TestDescription",
                    Type = "TestType",
                    DateAdded = DateTime.Now,
                    DateCompleted = DateTime.Now,
                    Deadline = DateTime.Now,
                    Priority = 4,
                    UserId = 1
                },
                new Task_
                {
                    Id = 3,
                    Name = "TestName",
                    Description  = "TestDescription",
                    Type = "TestType",
                    DateAdded = DateTime.Now,
                    DateCompleted = DateTime.Now,
                    Deadline = DateTime.Now,
                    Priority = 4,
                    UserId = 1
                },
                new Task_
                {
                    Id = 4,
                    Name = "TestName",
                    Description  = "TestDescription",
                    Type = "TestType",
                    DateAdded = DateTime.Now,
                    DateCompleted = DateTime.Now,
                    Deadline = DateTime.Now,
                    Priority = 4,
                    UserId = 3
                },
                new Task_
                {
                    Id = 5,
                    Name = "TestName",
                    Description  = "TestDescription",
                    Type = "TestType",
                    DateAdded = DateTime.Now,
                    DateCompleted = DateTime.Now,
                    Deadline = DateTime.Now,
                    Priority = 4,
                    UserId = 2
                },
                new Task_
                {
                    Id = 6,
                    Name = "TestName",
                    Description  = "TestDescription",
                    Type = "TestType",
                    DateAdded = DateTime.Now,
                    DateCompleted = DateTime.Now,
                    Deadline = DateTime.Now,
                    Priority = 4,
                    UserId = 2
                }
            };

            return tasks;
        }
    }
}
