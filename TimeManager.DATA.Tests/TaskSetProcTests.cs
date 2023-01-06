using System;
using TimeManager.DATA.Processors.TaskSetProcessor;
using NUnit.Framework;
using TimeManager.DATA.Data;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TimeManager.DATA.Controllers.TaskSetControllers;
using TimeManager.DATA.Tests.Data;

namespace TimeManager.DATA.Tests
{
    public class TaskSetProcTests
    {
        private Mock<DbSet<TaskSet>> GetMockDbSet()
        {
            var data = new List<TaskSet>()
            {
               new TaskSet 
               {
                   Id = 1,
                   UserId = 1,
                   TaskOccurencies = new List<TaskDate>
                   {

                   },
                   Task 
                },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<TaskSet>>();

            mockSet.As<IQueryable<TaskSet>>().Setup(t => t.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<TaskSet>>().Setup(t => t.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TaskSet>>().Setup(t => t.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<TaskSet>>().Setup(t => t.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet;
        }


        [Test]
        public void TaskSetPost_Should_PostTaskSet()
        {
            Assert.Pass();
        }

        [Test]
        public void TaskSetDelete_Should_DeleteTaskSet()
        {
            Assert.Pass();
        }

        [Test]
        public void TaskSetUpdate_Should_UpdateTaskSet()
        {
            Assert.Pass();
        }

        [Test]
        public void TaskSetGetAll_Should_ReturnAllTaskSets()
        {
            Assert.Pass();
        }

        [Test]
        public void TaskSetGetById_Should_ReturnTaskSetById()
        {
            Assert.Pass();
        }
    }
}
