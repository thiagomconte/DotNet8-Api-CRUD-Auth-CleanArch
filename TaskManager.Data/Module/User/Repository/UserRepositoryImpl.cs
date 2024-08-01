using TaskManager.Domain.Module.User.Model;
using TaskManager.Domain.Module.User.Repository;

namespace TaskManager.Data.Module.User.Repository
{
    public class UserRepositoryImpl : IUserRepository
    {
        public async Task<UserModel> IUserRepository.AddUserAsync(UserModel user)
        {

        }

        public async Task<List<UserModel>> IUserRepository.GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> IUserRepository.GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> IUserRepository.GetUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
