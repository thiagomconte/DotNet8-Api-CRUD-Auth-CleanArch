using AutoMapper;
using FluentAssertions;
using Moq;
using TaskManager.Data.Module.Task.DataSource;
using TaskManager.Data.Module.Task.Entity;
using TaskManager.Data.Module.Task.Mapper;
using TaskManager.Data.Module.Task.Repository;
using TaskManager.Data.Module.User.Mapper;
using TaskManager.Integration.Tests.Data.UserTask;

namespace TaskManager.Unit.Tests.UserTask.Repository
{
    public class TaskRepositoryTest
    {
        private readonly Mock<ITaskLocalDataSource> mock;
        private readonly IMapper _mapper;
        private readonly TaskRepositoryImpl taskRepository;

        public TaskRepositoryTest()
        {
            mock = new Mock<ITaskLocalDataSource>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TaskMappingProfile());
                mc.AddProfile(new UserMappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;

            mock.Setup(s => s.AddTaskAsync(It.IsAny<TaskEntity>())).ReturnsAsync(TaskMock.TaskEntity1);
            mock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(TaskMock.TaskEntity1);
            mock.Setup(s => s.GetAllAsync()).ReturnsAsync([TaskMock.TaskEntity1, TaskMock.TaskEntity2]);
            mock.Setup(s => s.AssignUserAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(TaskMock.TaskEntity3);

            taskRepository = new(mock.Object, _mapper);
        }

        [Fact]
        public async Task AddTaskAsync_ShouldAddTask()
        {
            // Act 
            var result = await taskRepository.AddAsync(TaskMock.Task1);

            // Assert
            result.Should().NotBeNull();
            result.Title.Should().Be(TaskMock.Task1.Title);
            result.Description.Should().Be(TaskMock.Task1.Description);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnTask()
        {
            // Act 
            var result = await taskRepository.GetByIdAsync(TaskMock.Task1.Id);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TaskMock.Task1.Id);
            result.Title.Should().Be(TaskMock.Task1.Title);
            result.Description.Should().Be(TaskMock.Task1.Description);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllTasks()
        {
            // Act 
            var result = await taskRepository.GetAllAsync();

            // Assert
            result.Should().NotBeNull();
            result[0].Id.Should().Be(TaskMock.Task1.Id);
            result[1].Id.Should().Be(TaskMock.Task2.Id);
        }

        [Fact]
        public async Task AssignUserAsync_ShouldReturnAllTasks()
        {
            // Act 
            var result = await taskRepository.AssignUserAsync(3, 3);

            // Assert
            result.Should().NotBeNull();
            result.UserId.Should().Be(TaskMock.Task3.UserId);
        }
    }
}
