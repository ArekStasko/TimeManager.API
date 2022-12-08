using System;
using TimeManager.DATA.Processors.actTaskProcessor;
using NUnit.Framework;
using FluentAssertions;
using TimeManager.DATA.Data;
using Moq;
using Microsoft.EntityFrameworkCore;

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

        [Test]
        public void actTaskAdd_Should_AddactTask()
        {
            var actTaskMock = new Mock<DbSet<ActTask>>();
            var actTask = new ActTask()
            {
                Id = 1,
                Name = "TestName",
                Description = "Test Description",
                CategoryId = 1,
                DateAdded = DateTime.Now,
                DateCompleted = DateTime.Now,
                Deadline = DateTime.Now,
                UserId = 1,
                Priority = 1,
            };

            //actTaskMock.Setup();

            var processor = actTaskProcessor_Factory.GetactTask_Add(mockDbContext.Object, null);
            var result = processor.Post(actTask);
            Assert.Pass();
        }

        [Test]
        public void actTaskDelete_Should_DeleteactTask()
        {
            var actTaskMock = new Mock<DbSet<ActTask>>();
            var actTask = new ActTask()
            {
                Id = 1,
                Name = "TestName",
                Description = "Test Description",
                CategoryId = 1,
                DateAdded = DateTime.Now,
                DateCompleted = DateTime.Now,
                Deadline = DateTime.Now,
                UserId = 1,
                Priority = 1,
            };

            //actTaskMock.Setup();

            var processor = actTaskProcessor_Factory.GetactTask_Delete(mockDbContext.Object, null);
            var result = processor.Delete(actTask);
            Assert.Pass();
        }

        [Test]
        public void actTaskGetAll_Should_ReturnAllActTasks()
        {
            var actTaskMock = new Mock<DbSet<ActTask>>();
            var actTask = new ActTask()
            {
                Id = 1,
                Name = "TestName",
                Description = "Test Description",
                CategoryId = 1,
                DateAdded = DateTime.Now,
                DateCompleted = DateTime.Now,
                Deadline = DateTime.Now,
                UserId = 1,
                Priority = 1,
            };

            //actTaskMock.Setup();

            var processor = actTaskProcessor_Factory.GetactTask_GetAll(mockDbContext.Object, null);
            var result = processor.Get();
            Assert.Pass();
        }

        [Test]
        public void actTaskGetByCategory_Should_ReturnActTasksByCategory()
        {
            var actTaskMock = new Mock<DbSet<ActTask>>();
            var actTask = new ActTask()
            {
                Id = 1,
                Name = "TestName",
                Description = "Test Description",
                CategoryId = 1,
                DateAdded = DateTime.Now,
                DateCompleted = DateTime.Now,
                Deadline = DateTime.Now,
                UserId = 1,
                Priority = 1,
            };

            //actTaskMock.Setup();

            var processor = actTaskProcessor_Factory.GetactTask_GetByCategory(mockDbContext.Object, null);
            var result = processor.Get();
            Assert.Pass();
        }

        [Test]
        public void actTaskById_Should_ReturnactTaskWithSpecificId()
        {
            var actTaskMock = new Mock<DbSet<ActTask>>();
            var actTask = new ActTask()
            {
                Id = 1,
                Name = "TestName",
                Description = "Test Description",
                CategoryId = 1,
                DateAdded = DateTime.Now,
                DateCompleted = DateTime.Now,
                Deadline = DateTime.Now,
                UserId = 1,
                Priority = 1,
            };

            //actTaskMock.Setup();

            var processor = actTaskProcessor_Factory.GetactTask_GetById(mockDbContext.Object, null);
            var result = processor.Get();
            Assert.Pass();
        }

        [Test]
        public void actTaskUpdate_Should_UpdateactTask()
        {
            var actTaskMock = new Mock<DbSet<ActTask>>();
            var actTask = new ActTask()
            {
                Id = 1,
                Name = "TestName",
                Description = "Test Description",
                CategoryId = 1,
                DateAdded = DateTime.Now,
                DateCompleted = DateTime.Now,
                Deadline = DateTime.Now,
                UserId = 1,
                Priority = 1,
            };

            //actTaskMock.Setup();

            var processor = actTaskProcessor_Factory.GetactTask_Update(mockDbContext.Object, null);
            var result = processor.Update();
            Assert.Pass();
        }
    }
}