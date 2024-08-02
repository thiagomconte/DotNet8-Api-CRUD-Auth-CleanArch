using FluentAssertions;
using TaskManager.Core.Module.Exceptions;
using TaskManager.Data.Module.User.Repository;
using TaskManager.Integration.Tests.Data;
using Xunit;

namespace TaskManager.Data.Test.User.Repository
{

    public class UserLocalDataSourceTest : BaseLocalDataSourceTest, IAsyncLifetime
    {
        private UserLocalDataSource _userLocalDataSource;

        public UserLocalDataSourceTest()
        {
            SetupDb();
            _userLocalDataSource = new UserLocalDataSource(_context);
        }

        public async Task InitializeAsync()
        {
            await _userLocalDataSource.AddUserAsync(UserMock.User1);
            await _userLocalDataSource.AddUserAsync(UserMock.User2);
            await _context.SaveChangesAsync();
        }

        public Task DisposeAsync()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
            return Task.CompletedTask;
        }

        [Fact]
        public async Task AddUserAsync_AddsUserToDatabase()
        {
            // Act
            var result = await _userLocalDataSource.AddUserAsync(UserMock.User3);

            // Assert
            result.Id.Should().Be(3);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllUsers()
        {

            // Act
            var result = await _userLocalDataSource.GetUsersAsync();

            // Assert
            result.Count.Should().Be(2);
        }

        [Fact]
        public async Task GetUserByIdAsync_ReturnsUser()
        {
            // Act
            var result = await _userLocalDataSource.GetUserByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
        }

        [Fact]
        public async Task GetUserByEmailAsync_ReturnsUser()
        {

            // Arrange
            await _userLocalDataSource.AddUserAsync(UserMock.User4);
            // Act
            var result = await _userLocalDataSource.GetUserByEmailAsync(UserMock.User4.Email);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(UserMock.User4.Id);
        }

        [Fact]
        public async Task GetUserByIdAsync_ThrowsException_WhenUserNotFound()
        {

            // Act
            Func<Task> act = async () => await _userLocalDataSource.GetUserByIdAsync(99);

            // Assert
            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task GetUserByEmailAsync_ThrowsException_WhenUserNotFound()
        {
            // Act
            Func<Task> act = async () => await _userLocalDataSource.GetUserByEmailAsync("nonexistent@example.com");

            // Assert
            await act.Should().ThrowAsync<EntityNotFoundException>();
        }
    }
}
