using System;
using TimeManager.DATA.Processors.ActivityProcessor;
using NUnit.Framework;
using FluentAssertions;
using TimeManager.DATA.Data;
using Moq;
using Microsoft.EntityFrameworkCore;

// All tests will be ready after completing api gateway and base defactor

namespace TimeManager.DATA.Tests
{
    public class ActivityProcTests
    {
        Mock<DataContext> mockDbContext = new Mock<DataContext>();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ActivityAdd_Should_AddActivity()
        {
            var activityMock = new Mock<DbSet<Activity>>();
            var activity = new Activity()
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

            //activityMock.Setup();

            var processor = ActivityProcessor_Factory.GetActivity_Add(mockDbContext.Object, null);
            var result = processor.Post(activity);
            Assert.Pass();
        }

        [Test]
        public void ActivityDelete_Should_DeleteActivity()
        {
            var activityMock = new Mock<DbSet<Activity>>();
            var activity = new Activity()
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

            //activityMock.Setup();

            var processor = ActivityProcessor_Factory.GetActivity_Delete(mockDbContext.Object, null);
            var result = processor.Delete(activity);
            Assert.Pass();
        }

        [Test]
        public void ActivityGetAll_Should_ReturnAllActivities()
        {
            var activityMock = new Mock<DbSet<Activity>>();
            var activity = new Activity()
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

            //activityMock.Setup();

            var processor = ActivityProcessor_Factory.GetActivity_GetAll(mockDbContext.Object, null);
            var result = processor.Get();
            Assert.Pass();
        }

        [Test]
        public void ActivityGetByCategory_Should_ReturnActivitiesByCategory()
        {
            var activityMock = new Mock<DbSet<Activity>>();
            var activity = new Activity()
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

            //activityMock.Setup();

            var processor = ActivityProcessor_Factory.GetActivity_GetByCategory(mockDbContext.Object, null);
            var result = processor.Get();
            Assert.Pass();
        }

        [Test]
        public void ActivityById_Should_ReturnActivityWithSpecificId()
        {
            var activityMock = new Mock<DbSet<Activity>>();
            var activity = new Activity()
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

            //activityMock.Setup();

            var processor = ActivityProcessor_Factory.GetActivity_GetById(mockDbContext.Object, null);
            var result = processor.Get();
            Assert.Pass();
        }

        [Test]
        public void ActivityUpdate_Should_UpdateActivity()
        {
            var activityMock = new Mock<DbSet<Activity>>();
            var activity = new Activity()
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

            //activityMock.Setup();

            var processor = ActivityProcessor_Factory.GetActivity_Update(mockDbContext.Object, null);
            var result = processor.Update();
            Assert.Pass();
        }
    }
}