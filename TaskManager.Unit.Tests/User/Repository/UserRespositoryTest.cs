using AutoMapper;
using FluentAssertions;
using Moq;
using TaskManager.Data.Module.User.Entity;
using TaskManager.Data.Module.User.Mapper;
using TaskManager.Data.Module.User.Repository;
using TaskManager.Data.Test.User;

namespace TaskManager.Unit.Tests.User.Repository
{
    public class UserRespositoryTest
    {
        private readonly Mock<IUserLocalDataSource> mock;
        private readonly IMapper _mapper;
        private readonly UserRepositoryImpl userRepository;

        public UserRespositoryTest()
        {
            mock = new Mock<IUserLocalDataSource>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserMappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
            mock.Setup(s => s.AddUserAsync(It.IsAny<UserEntity>())).ReturnsAsync(UserMock.UserEntity1);
            mock.Setup(s => s.GetUsersAsync()).ReturnsAsync([UserMock.UserEntity1.SetId(1), UserMock.UserEntity2.SetId(2)]);
            mock.Setup(s => s.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync(UserMock.UserEntity1);
            mock.Setup(s => s.GetUserByEmailAsync(It.IsAny<string>())).ReturnsAsync(UserMock.UserEntity1);
            userRepository = new(mock.Object, _mapper);
        }

        [Fact]
        public async Task AddUserAsync_ShouldAddUser()
        {
            // Act 
            var result = await userRepository.AddUserAsync(UserMock.User1);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(UserMock.User1.Name);
            result.Email.Should().Be(UserMock.User1.Email);
        }

        [Fact]
        public async Task GetUserByEmailAsync_ShouldReturnUser()
        {
            // Act
            var result = await userRepository.GetUserByEmailAsync(UserMock.User1.Email);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(UserMock.User1.Name);
            result.Email.Should().Be(UserMock.User1.Email);
        }

        [Fact]
        public async Task GetUserByIdAsync_ShouldReturnUser()
        {

            // Act
            var result = await userRepository.GetUserByIdAsync(UserMock.User1.Id);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(UserMock.User1.Name);
            result.Email.Should().Be(UserMock.User1.Email);
        }

        [Fact]
        public async Task GetUsersAsync_ShouldReturnAllUsers()
        {
            // Act
            var result = await userRepository.GetUsersAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result[0].Id.Should().Be(1);
            result[1].Id.Should().Be(2);
        }
    }
}
