using NUnit.Framework;
using FluentAssertions;
using TimeManager.API.Data;
using TimeManager.API.Processors.CategoryProcessor;

namespace TimeManager.API.Tests
{
    public class CategoryProcTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CategoryAdd_Should_AddCategory()
        {
           // var processor = CategoryProcessor_Factory.GetCategory_Add();
            Assert.Pass();
        }

        [Test]
        public void CategoryDelete_Should_DeleteCategory()
        {
            //var processor = CategoryProcessor_Factory.GetCategory_Delete();
            Assert.Pass();
        }

        [Test]
        public void CategoryGet_Should_ReturnCategory()
        {
           // var processor = CategoryProcessor_Factory.GetCategory_Get();
            Assert.Pass();
        }

        [Test]
        public void CategoryUpdate_Should_UpdateCategory()
        {
            //var processor = CategoryProcessor_Factory.GetCategory_Update();
            Assert.Pass();
        }
    }
}
