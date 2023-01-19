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
            var data = new List<TaskSet>
            {
               new TaskSet 
               {
                   Id = 1,
                   UserId = 1,
                   TaskOccurencies = new List<TaskDate>
                   {
                       new TaskDate
                       {
                           Id=1,
                           Date = DateTime.Now,
                       }
                   },
                   Task = new Task_
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
                    }
               },
               new TaskSet
               {
                   Id = 2,
                   UserId = 2,
                   TaskOccurencies = new List<TaskDate>
                   {
                       new TaskDate
                       {
                           Id=2,
                           Date = DateTime.Now,
                       }
                   },
                   Task = new Task_
                    {
                     Id = 2,
                     Name = "TestName",
                     Description  = "TestDescription",
                     Type = "TestType",
                     DateAdded = DateTime.Now,
                     DateCompleted = DateTime.Now,
                     Deadline = DateTime.Now,
                     Priority = 4,
                     UserId = 2
                    }
               },
               new TaskSet
               {
                   Id = 3,
                   UserId = 3,
                   TaskOccurencies = new List<TaskDate>
                   {
                       new TaskDate
                       {
                           Id=3,
                           Date = DateTime.Now,
                       }
                   },
                   Task = new Task_
                    {
                     Id = 3,
                     Name = "TestName",
                     Description  = "TestDescription",
                     Type = "TestType",
                     DateAdded = DateTime.Now,
                     DateCompleted = DateTime.Now,
                     Deadline = DateTime.Now,
                     Priority = 4,
                     UserId = 3
                    }
               }
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
            var mockSet = new Mock<DbSet<TaskSet>>();

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.TaskSets).Returns(mockSet.Object);

            var service = new TaskSet_Post(mockContext.Object, new MockLogger<TaskSetController>(), new MockMQ_True());

            var testTask = new TaskSet
            {
                Id = 1,
                UserId = 1,
                TaskOccurencies = new List<TaskDate>
                   {
                       new TaskDate
                       {
                           Id=1,
                           Date = DateTime.Now,
                       }
                   },
                Task = new Task_
                {
                    Id = 1,
                    Name = "TestName",
                    Description = "TestDescription",
                    Type = "TestType",
                    DateAdded = DateTime.Now,
                    DateCompleted = DateTime.Now,
                    Deadline = DateTime.Now,
                    Priority = 4,
                    UserId = 1
                }
            };

            var result = service.Execute(new Request<TaskSet>() { Data = testTask, userId = 1 });

            Assert.True(result != null);
            _ = result.Result.Match<bool>(succ =>
            {
                Assert.IsTrue(succ);
                mockSet.Verify(tsk => tsk.Add(It.IsAny<TaskSet>()), Times.Once);
                mockContext.Verify(tsk => tsk.SaveChanges(), Times.Once);
                return true;
            }, exception =>
            {
                Assert.Fail(exception.Message);
                return false;
            });
        }

        [Test]
        public void TaskSetDelete_Should_DeleteTaskSet()
        {
            var mockSet = GetMockDbSet();
            var TaskToDelete = mockSet.Object.Single(tsk => tsk.Id == 1 && tsk.UserId == 1);

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.TaskSets).Returns(mockSet.Object);

            var service = new TaskSet_Delete(mockContext.Object, new MockLogger<TaskSetController>(), new MockMQ_True());

            var result = service.Execute(taskSetId: TaskToDelete.Id, userId: TaskToDelete.UserId);

            Assert.True(result != null);
            _ = result.Result.Match<bool>(succ =>
            {
                Assert.IsTrue(succ);
                mockSet.Verify(tsk => tsk.Remove(TaskToDelete), Times.Once);
                mockContext.Verify(tsk => tsk.SaveChanges(), Times.Once);
                return true;
            }, exception =>
            {
                Assert.Fail(exception.Message);
                return false;
            });
        }

        [Test]
        public void TaskSetUpdate_Should_UpdateTaskSet()
        {
            var mockSet = GetMockDbSet();
            var TaskToUpdate = mockSet.Object.Single(tsk => tsk.Id == 1 && tsk.UserId == 1);

            TaskToUpdate.TaskOccurencies.Add(new TaskDate { Id = 4, Date = DateTime.Now });

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.TaskSets).Returns(mockSet.Object);

            var service = new TaskSet_Update(mockContext.Object, new MockLogger<TaskSetController>(), new MockMQ_True());

            var result = service.Execute(new Request<TaskSet> { Data = TaskToUpdate, userId = 1});

            Assert.True(result != null);
            _ = result.Result.Match<bool>(succ =>
            {
                Assert.IsTrue(succ);
                mockSet.Verify(tsk => tsk.Remove(TaskToUpdate), Times.Once);
                mockSet.Verify(tsk => tsk.Add(It.IsAny<TaskSet>()), Times.Once);
                mockContext.Verify(tsk => tsk.SaveChanges(), Times.Once);
                return true;
            }, exception =>
            {
                Assert.Fail(exception.Message);
                return false;
            });
        }

        [Test]
        public void TaskSetGetAll_Should_ReturnAllTaskSets()
        {
            var mockSet = GetMockDbSet();

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.TaskSets).Returns(mockSet.Object);

            var service = new TaskSet_GetAll(mockContext.Object, new MockLogger<TaskSetController>());

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
        public void TaskSetGetById_Should_ReturnTaskSetById()
        {
            var mockSet = GetMockDbSet();

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.TaskSets).Returns(mockSet.Object);

            var service = new TaskSet_GetById(mockContext.Object, new MockLogger<TaskSetController>());

            var result = service.Execute(taskSetId: 2, userId: 2);

            Assert.True(result != null);
            _ = result.Result.Match<bool>(taskSet =>
            {
                Assert.AreEqual(2, taskSet.Id);
                Assert.AreEqual(2, taskSet.UserId);
                return true;
            }, exception =>
            {
                Assert.Fail(exception.Message);
                return false;
            });
        }
    }
}
