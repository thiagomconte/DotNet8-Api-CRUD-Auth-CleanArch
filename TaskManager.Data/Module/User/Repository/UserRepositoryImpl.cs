using TaskManager.Data.Module.User.Mapper;
using TaskManager.Domain.Module.User.Model;
using TaskManager.Domain.Module.User.Repository;

namespace TaskManager.Data.Module.User.Repository
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly UserLocalDataSource _dataSource;

        public UserRepositoryImpl(UserLocalDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<UserModel> AddUserAsync(UserModel user)
        {
            var userEntity = UserMapper.ToEntity(user);
            var insertedUser = await _dataSource.AddUserAsync(userEntity);
            return UserMapper.ToDomain(insertedUser);
        }

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            var user = await _dataSource.GetUserByEmailAsync(email);
            return UserMapper.ToDomain(user);
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var user = await _dataSource.GetUserByIdAsync(id);
            return UserMapper.ToDomain(user);
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            var users = await _dataSource.GetUsersAsync();
            return UserMapper.ToDomain(users);
        }
    }
}
