using TaskManager.Data.Module.User.Entity;

namespace TaskManager.Data.Module.User.Repository
{
    public interface IUserLocalDataSource
    {

        public Task<UserEntity> AddUserAsync(UserEntity user);

        public Task<List<UserEntity>> GetUsersAsync();

        public Task<UserEntity> GetUserByIdAsync(int id);

        public Task<UserEntity> GetUserByEmailAsync(string email);
    }
}
