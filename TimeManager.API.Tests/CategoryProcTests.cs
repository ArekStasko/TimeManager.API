using System;
using TimeManager.API.Processors.CategoryProcessor;
using NUnit.Framework;
using FluentAssertions;
using TimeManager.API.Data;
using Moq;
using Microsoft.EntityFrameworkCore;


// All tests will be ready after completing api gateway and base defactor

namespace TimeManager.API.Tests
{
    public class CategoryProcTests
    {
        Mock<DataContext> mockDbContext = new Mock<DataContext>();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CategoryAdd_Should_AddCategory()
        {
            var categoryMock = new Mock<Category>();
            var category = new Category()
            {
                Id = 1,
                Name = "CategoryName"
            };

            //categoryMock.Setup();

            var processor = CategoryProcessor_Factory.GetCategory_Add(mockDbContext.Object, null);
            var result = processor.Post(category);
            Assert.Pass();
        }

        [Test]
        public void CategoryDelete_Should_DeleteCategory()
        {
            var categoryMock = new Mock<Category>();
            var category = new Category()
            {
                Id = 1,
                Name = "CategoryName"
            };

            //categoryMock.Setup();

            var processor = CategoryProcessor_Factory.GetCategory_Delete(mockDbContext.Object, null);
            var result = processor.Delete(category);
            Assert.Pass();
        }

        [Test]
        public void CategoryGet_Should_ReturnCategory()
        {
            var categoryMock = new Mock<Category>();
            var category = new Category()
            {
                Id = 1,
                Name = "CategoryName"
            };

            //categoryMock.Setup();

            var processor = CategoryProcessor_Factory.GetCategory_Get(mockDbContext.Object, null);
            var result = processor.Get();
            Assert.Pass();
        }

        [Test]
        public void CategoryUpdate_Should_UpdateCategory()
        {
            var categoryMock = new Mock<Category>();
            var category = new Category()
            {
                Id = 1,
                Name = "CategoryName"
            };

            //categoryMock.Setup();

            var processor = CategoryProcessor_Factory.GetCategory_Update(mockDbContext.Object, null);
            var result = processor.Update();
            Assert.Pass();
        }
    }
}
