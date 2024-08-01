using TaskManager.Domain.Module.User.Model;
using TaskManager.Domain.Module.User.Repository;

namespace TaskManager.Domain.Module.User.Usecase
{
    public class AddUserUsecase
    {
        private readonly IUserRepository _userRepository;

        public AddUserUsecase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> Invoke(UserModel user)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hashedPassword;
            return await _userRepository.AddUserAsync(user);
        }
    }
}
