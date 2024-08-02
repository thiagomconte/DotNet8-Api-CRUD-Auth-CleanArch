using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Module.Exceptions;
using TaskManager.Data.Module.Database;
using TaskManager.Data.Module.User.Repository;
using TaskManager.Data.Module.UserTask.Repository;
using TaskManager.Data.Test.User;

namespace TaskManager.Integration.Tests.Data.UserTask.Repository
{
    [TestClass]
    public class TaskLocalDataSourceTest : BaseLocalDataSourceTest
    {

        private TaskLocalDataSource _taskLocalDataSource;
        private UserLocalDataSource _userLocalDataSource;

        [TestInitialize]
        public void Setup()
        {
            SetupDb();
            _taskLocalDataSource = new TaskLocalDataSource(_context);
            _userLocalDataSource = new UserLocalDataSource(_context);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnsAllTasks()
        {
            // Arrange
            await _taskLocalDataSource.AddTaskAsync(TaskMock.Task1);
            await _taskLocalDataSource.AddTaskAsync(TaskMock.Task2);
            await _taskLocalDataSource.AddTaskAsync(TaskMock.Task3);

            // Act
            var result = await _taskLocalDataSource.GetAllAsync();

            // Assert
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsTask()
        {
            // Arrange
            await _taskLocalDataSource.AddTaskAsync(TaskMock.Task1);

            // Act
            var result = await _taskLocalDataSource.GetByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public async Task GetByIdAsync_ThrowsException_WhenTaskNotFound()
        {
            // Act & Assert
            await Assert.ThrowsExceptionAsync<EntityNotFoundException>(async () =>
                await _taskLocalDataSource.GetByIdAsync(78));
        }

        [TestMethod]
        public async Task AddTaskAsync_AddsTaskToDatabase()
        {
            // Act
            var result = await _taskLocalDataSource.AddTaskAsync(TaskMock.Task2);

            // Assert
            Assert.AreEqual(TaskMock.Task2.Id, result.Id);
            Assert.AreEqual(TaskMock.Task2.Title, result.Title);
        }

        [TestMethod]
        public async Task AssignUserAsync_AssignsUserToTask()
        {
            // Arrange
            await _userLocalDataSource.AddUserAsync(UserMock.User1);
            await _taskLocalDataSource.AddTaskAsync(TaskMock.Task1);
            await _taskLocalDataSource.AddTaskAsync(TaskMock.Task2);

            // Act
            var result = await _taskLocalDataSource.AssignUserAsync(UserMock.User1.Id, TaskMock.Task2.Id);

            // Assert
            Assert.AreEqual(UserMock.User1.Id, result.UserId);
        }
    }
}
