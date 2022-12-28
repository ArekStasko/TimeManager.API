using System;
using TimeManager.DATA.Processors.TaskProcessor;
using NUnit.Framework;
using FluentAssertions;
using TimeManager.DATA.Data;
using Moq;
using Autofac.Extras.Moq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// All tests will be ready after completing api gateway and base defactor

namespace TimeManager.DATA.Tests
{
    public class actTaskProcTests
    {
        Mock<DataContext> mockDbContext = new Mock<DataContext>();

        [SetUp]
        public void Setup()
        {
            
        }

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

        [Test]
        public void TaskAdd_Should_AddTask()
        {
            
            var taskMock = new Mock<DbSet<Task_>>();


            Assert.Pass();
        }

        [Test]
        public void TaskDelete_Should_DeleteTask()
        {
            var taskMock = new Mock<DbSet<Task_>>();
            

            Assert.Pass();
        }

        [Test]
        public void TaskGetAll_Should_ReturnAllTasks()
        {
            var taskMock = new Mock<DbSet<Task_>>();

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<DataContext>()
                    .Setup(x => x.Tasks)
                    .Returns(GetTasks);

                var proc = mock.Create<Task_GetAll>();
                var expected = GetTasks().Where(t => t.UserId == 1);

                var actual = proc.Execute(userId: 1);
                Assert.True(actual != null);
                actual.Result.Should().BeEquivalentTo(expected);
            }

        }

        [Test]
        public void actTaskGetByCategory_Should_ReturnActTasksByCategory()
        {
            var taskMock = new Mock<DbSet<Task_>>();

            Assert.Pass();
        }

        [Test]
        public void TaskById_Should_ReturnTaskWithSpecificId()
        {
            var taskMock = new Mock<DbSet<Task_>>();
           
            Assert.Pass();
        }

        [Test]
        public void TaskUpdate_Should_UpdateTask()
        {
            var actTaskMock = new Mock<DbSet<Task_>>();

            Assert.Pass();
        }
    }
}