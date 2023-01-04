using System;
using TimeManager.DATA.Processors.TaskProcessor;
using NUnit.Framework;
using TimeManager.DATA.Data;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TimeManager.DATA.Controllers.TaskControllers;
using TimeManager.DATA.Tests.Data;

namespace TimeManager.DATA.Tests
{
    public class TaskProcTests
    {
        private Mock<DbSet<Task_>> GetMockDbSet()
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

            return mockSet;
        }


        [Test]
        public void TaskPost_Should_PostTask()
        {
            var mockSet = new Mock<DbSet<Task_>>();

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.Tasks).Returns(mockSet.Object);

            var service = new Task_Post(mockContext.Object, new MockLogger<TaskController>(), new MockMQ_True());

            var testTask = new Task_
            {
                Id = 7,
                Name = "TestName",
                Description = "TestDescription",
                Type = "TestType",
                DateAdded = DateTime.Now,
                DateCompleted = DateTime.Now,
                Deadline = DateTime.Now,
                Priority = 4,
                UserId = 1
            };

            var result = service.Execute(new Request<Task_>() { Data = testTask, userId = 1});

            Assert.True(result != null);
            _ = result.Result.Match<bool>(succ =>
            {
                Assert.IsTrue(succ);
                mockSet.Verify(tsk => tsk.Add(It.IsAny<Task_>()), Times.Once);
                mockContext.Verify(tsk => tsk.SaveChanges(), Times.Once);
                return true;
            }, exception =>
            {
                Assert.Fail(exception.Message);
                return false;
            });
        }

        [Test]
        public void TaskPost_ShouldNot_PostTask()
        {

            var mockSet = new Mock<DbSet<Task_>>();

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.Tasks).Returns(mockSet.Object);

            var service = new Task_Post(mockContext.Object, new MockLogger<TaskController>(), new MockMQ_False());

            var testTask = new Task_
            {
                Id = 7,
                Name = "TestName",
                Description = "TestDescription",
                Type = "TestType",
                DateAdded = DateTime.Now,
                DateCompleted = DateTime.Now,
                Deadline = DateTime.Now,
                Priority = 4,
                UserId = 1
            };

            var result = service.Execute(new Request<Task_>() { Data = testTask, userId = 1 });

            Assert.True(result != null);
            _ = result.Result.Match<bool>(succ =>
            {
                Assert.IsFalse(succ);
                mockSet.Verify(tsk => tsk.Add(It.IsAny<Task_>()), Times.Once);
                mockContext.Verify(tsk => tsk.SaveChanges(), Times.Once);
                return true;
            }, exception =>
            {
                Assert.Fail(exception.Message);
                return false;
            });
        }

        [Test]
        public void TaskDelete_Should_DeleteTask()
        {
            var mockSet = GetMockDbSet();
            var TaskToDelete = mockSet.Object.Single(tsk => tsk.Id == 1 && tsk.UserId == 1);

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.Tasks).Returns(mockSet.Object);

            var service = new Task_Delete(mockContext.Object, new MockLogger<TaskController>(), new MockMQ_True());

            var result = service.Execute(taskId: TaskToDelete.Id, userId: TaskToDelete.UserId);

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
        public void TaskDelete_ShouldNot_DeleteTask()
        {
            var mockSet = GetMockDbSet();
            var TaskToDelete = mockSet.Object.Single(tsk => tsk.Id == 1 && tsk.UserId == 1);

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.Tasks).Returns(mockSet.Object);

            var service = new Task_Delete(mockContext.Object, new MockLogger<TaskController>(), new MockMQ_False());

            var result = service.Execute(taskId: TaskToDelete.Id, userId: TaskToDelete.UserId);

            Assert.True(result != null);
            _ = result.Result.Match<bool>(succ =>
            {
                Assert.IsFalse(succ);
                mockSet.Verify(tsk => tsk.Remove(TaskToDelete), Times.Once);
                mockSet.Verify(tsk => tsk.Add(It.IsAny<Task_>()), Times.Once);
                mockContext.Verify(tsk => tsk.SaveChanges(), Times.Once);
                return true;
            }, exception =>
            {
                Assert.Fail(exception.Message);
                return false;
            });
        }

        [Test]
        public void TaskUpdate_Should_UpdateTask()
        {

            var mockSet = GetMockDbSet();
            var TaskToUpdate = mockSet.Object.Single(tsk => tsk.Id == 1 && tsk.UserId == 1);

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.Tasks).Returns(mockSet.Object);

            var service = new Task_Update(mockContext.Object, new MockLogger<TaskController>(), new MockMQ_True());

            var result = service.Execute(new Request<Task_>() { Data = TaskToUpdate, userId = 1});

            Assert.True(result != null);
            _ = result.Result.Match<bool>(succ =>
            {
                Assert.IsTrue(succ);
                mockSet.Verify(tsk => tsk.Remove(TaskToUpdate), Times.Once);
                mockSet.Verify(tsk => tsk.Add(It.IsAny<Task_>()), Times.Once);
                mockContext.Verify(tsk => tsk.SaveChanges(), Times.Once);
                return true;
            }, exception =>
            {
                Assert.Fail(exception.Message);
                return false;
            });
        }

        [Test]
        public void TaskUpdate_ShouldNot_UpdateTask()
        {

            var mockSet = GetMockDbSet();
            var TaskToUpdate = mockSet.Object.Single(tsk => tsk.Id == 1 && tsk.UserId == 1);

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.Tasks).Returns(mockSet.Object);

            var service = new Task_Update(mockContext.Object, new MockLogger<TaskController>(), new MockMQ_False());

            var result = service.Execute(new Request<Task_>() { Data = TaskToUpdate, userId = 1 });

            Assert.True(result != null);
            _ = result.Result.Match<bool>(succ =>
            {
                Assert.IsFalse(succ);
                mockSet.Verify(tsk => tsk.Remove(TaskToUpdate), Times.Exactly(2));
                mockSet.Verify(tsk => tsk.Add(It.IsAny<Task_>()), Times.Exactly(2));
                mockContext.Verify(tsk => tsk.SaveChanges(), Times.Once);
                return true;
            }, exception =>
            {
                Assert.Fail(exception.Message);
                return false;
            });
        }

        [Test]
        public void TaskGetAll_Should_ReturnAllTasks()
        {
            var mockSet = GetMockDbSet();

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.Tasks).Returns(mockSet.Object);

            var service = new Task_GetAll(mockContext.Object, new MockLogger<TaskController>());

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
        public void TaskById_Should_ReturnTaskWithSpecificId()
        {
            var mockSet = GetMockDbSet();

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.Tasks).Returns(mockSet.Object);

            var service = new Task_GetById(mockContext.Object, new MockLogger<TaskController>());

            var result = service.Execute(taskId: 5, userId: 2);

            Assert.True(result != null);
            _ = result.Result.Match<bool>(task =>
            {
                Assert.AreEqual(5, task.Id);
                Assert.AreEqual(2, task.UserId);
                return true;
            }, exception =>
            {
                Assert.Fail(exception.Message);
                return false;
            });
        }
    }
}