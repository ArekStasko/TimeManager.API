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
using Microsoft.AspNetCore.Mvc;
using LanguageExt.Common;

namespace TimeManager.DATA.Tests
{
    public class actTaskProcTests
    {
        Mock<DataContext> mockDbContext = new Mock<DataContext>();

        [SetUp]
        public void Setup()
        {
            
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
            var data = new List<Task_>()
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
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Task_>>();

            mockSet.As<IQueryable<Task_>>().Setup(t => t.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Task_>>().Setup(t => t.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Task_>>().Setup(t => t.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Task_>>().Setup(t => t.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.Tasks).Returns(mockSet.Object);

            var service = new Task_GetAll(mockContext.Object, null);

            var result = service.Execute(userId: 1);
            
            Assert.True(result != null);
            _ = result.Result.Match<bool>(tasks =>
            {
                foreach (var task in tasks) Assert.AreEqual(1, task.UserId);
                return true;
            }, exception =>
            {
                Assert.Fail(exception.Message);
                return false;
            });
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