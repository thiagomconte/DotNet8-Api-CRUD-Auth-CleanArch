using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Module.Exceptions;
using TaskManager.Data.Module.Database;
using TaskManager.Data.Module.User.Repository;

namespace TaskManager.Data.Test.User.Repository
{

    [TestClass]
    public class UserLocalDataSourceTest
    {

        private DbContextOptions<TaskManagerDbContext> _options;
        private TaskManagerDbContext _context;
        private UserLocalDataSource _userLocalDataSource;

        [TestInitialize]
        public void Setup()
        {
            // Configura o banco de dados em memória
            _options = new DbContextOptionsBuilder<TaskManagerDbContext>()
                        .UseInMemoryDatabase(databaseName: "TaskManagerTestDb")
                        .Options;

            _context = new TaskManagerDbContext(_options);
            _userLocalDataSource = new UserLocalDataSource(_context);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [TestMethod]
        public async Task AddUserAsync_AddsUserToDatabase()
        {
            // Act
            var result = await _userLocalDataSource.AddUserAsync(UserMock.User1);

            // Assert
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnsAllUsers()
        {
            // Arrange
            await _userLocalDataSource.AddUserAsync(UserMock.User1);
            await _userLocalDataSource.AddUserAsync(UserMock.User2);
            await _userLocalDataSource.AddUserAsync(UserMock.User3);

            // Act
            var result = await _userLocalDataSource.GetUsersAsync();

            // Assert
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public async Task GetUserByIdAsync_ReturnsUser()
        {
            // Arrange
            await _userLocalDataSource.AddUserAsync(UserMock.User1);

            // Act
            var result = await _userLocalDataSource.GetUserByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public async Task GetUserByEmailAsync_ReturnsUser()
        {
            // Arrange
            await _userLocalDataSource.AddUserAsync(UserMock.User1);

            // Act
            var result = await _userLocalDataSource.GetUserByEmailAsync(UserMock.User1.Email);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public async Task GetUserByIdAsync_ThrowsException_WhenUserNotFound()
        {
            // Act & Assert
            await Assert.ThrowsExceptionAsync<EntityNotFoundException>(async () =>
                await _userLocalDataSource.GetUserByIdAsync(99));
        }

        [TestMethod]
        public async Task GetUserByEmailAsync_ThrowsException_WhenUserNotFound()
        {
            // Act & Assert
            await Assert.ThrowsExceptionAsync<EntityNotFoundException>(async () =>
                await _userLocalDataSource.GetUserByEmailAsync("nonexistent@example.com"));
        }
    }
}
