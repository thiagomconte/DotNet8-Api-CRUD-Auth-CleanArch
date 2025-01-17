﻿using FluentAssertions;
using TaskManager.Core.Module.Exceptions;
using TaskManager.Data.Module.Task.DataSource;
using TaskManager.Data.Module.User.DataSource;
using TaskManager.Data.Test.User;
using Xunit;

namespace TaskManager.Integration.Tests.Data.UserTask.DataSource
{
    public class TaskLocalDataSourceTest : BaseLocalDataSourceTest, IAsyncLifetime
    {

        private TaskLocalDataSource _taskLocalDataSource;
        private UserLocalDataSource _userLocalDataSource;

        public TaskLocalDataSourceTest()
        {
            SetupDb();
            _taskLocalDataSource = new TaskLocalDataSource(_context);
            _userLocalDataSource = new UserLocalDataSource(_context);
        }

        public async Task InitializeAsync()
        {
            await _taskLocalDataSource.AddTaskAsync(TaskMock.TaskEntity1);
            await _taskLocalDataSource.AddTaskAsync(TaskMock.TaskEntity2);
            await _context.SaveChangesAsync();
        }

        public Task DisposeAsync()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
            return Task.CompletedTask;
        }


        [Fact]
        public async Task GetAllAsync_ReturnsAllTasks()
        {
            // Act
            var result = await _taskLocalDataSource.GetAllAsync();

            // Assert
            result.Count.Should().Be(2);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsTask()
        {
            // Act
            var result = await _taskLocalDataSource.GetByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
        }

        [Fact]
        public async Task GetByIdAsync_ThrowsException_WhenTaskNotFound()
        {
            // Act
            Func<Task> act = async () => await _taskLocalDataSource.GetByIdAsync(78);

            // Assert
            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task AddTaskAsync_AddsTaskToDatabase()
        {
            // Act
            var result = await _taskLocalDataSource.AddTaskAsync(TaskMock.TaskEntity3);

            // Assert
            result.Id.Should().Be(TaskMock.TaskEntity3.Id);
            result.Title.Should().Be(TaskMock.TaskEntity3.Title);
        }

        [Fact]
        public async Task AssignUserAsync_AssignsUserToTask()
        {

            // Act
            var result = await _taskLocalDataSource.AssignUserAsync(UserMock.UserEntity1.Id, TaskMock.TaskEntity2.Id);

            // Assert
            result.UserId.Should().Be(UserMock.UserEntity1.Id);
        }
    }
}
