using TaskManager.Domain.Module.User.Model;
using TaskManager.Domain.Module.User.Repository;

namespace TaskManager.Domain.Module.User.Usecase
{
    public class GetAllUsersUsecase
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersUsecase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserModel>> Invoke()
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}
