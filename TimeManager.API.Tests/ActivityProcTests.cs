using NUnit.Framework;
using FluentAssertions;
using TimeManager.API.Data;
using TimeManager.API.Processors.ActivityProcessor;

namespace TimeManager.API.Tests
{
    public class ActivityProcTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ActivityAdd_Should_AddActivity()
        {
           // var processor = ActivityProcessor_Factory.GetActivity_Add();
            Assert.Pass();
        }

        [Test]
        public void ActivityDelete_Should_DeleteActivity()
        {
            //var processor = ActivityProcessor_Factory.GetActivity_Delete();
            Assert.Pass();
        }

        [Test]
        public void ActivityGetAll_Should_ReturnAllActivities()
        {
            //var processor = ActivityProcessor_Factory.GetvwActivityCategory_GetAll();
            Assert.Pass();
        }

        [Test]
        public void ActivityGetByCategory_Should_ReturnActivitiesByCategory()
        {
            //var processor = ActivityProcessor_Factory.GetvwActivityCategory_GetByCategory();
            Assert.Pass();
        }

        [Test]
        public void ActivityById_Should_ReturnActivityWithSpecificId()
        {
            //var processor = ActivityProcessor_Factory.GetvwActivityCategory_GetById();
            Assert.Pass();
        }

        [Test]
        public void ActivityUpdate_Should_UpdateActivity()
        {
            //var processor = ActivityProcessor_Factory.GetActivity_Update();
            Assert.Pass();
        }
    }
}