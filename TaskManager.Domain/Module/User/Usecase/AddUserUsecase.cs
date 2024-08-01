using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return await _userRepository.AddUserAsync(user);
        }
    }
}
