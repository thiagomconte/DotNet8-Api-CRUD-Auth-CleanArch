using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Module.Exceptions;
using TaskManager.Domain.Module.User.Model;
using TaskManager.Domain.Module.User.Repository;

namespace TaskManager.Domain.Module.User.Usecase
{
    public class GetUserByCredentialsUsecase
    {
        private readonly IUserRepository _userRepository;

        public GetUserByCredentialsUsecase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> Invoke(string email, string password)
        {
            try
            {
                var existingUser = await _userRepository.GetUserByEmailAsync(email);
                if (!BCrypt.Net.BCrypt.Verify(password, existingUser.Password))
                {
                    throw new InvalidCredentialsException("Credenciais inválidas");
                }
                return existingUser;
            }
            catch (Exception)
            {
                throw new InvalidCredentialsException("Credenciais inválidas");
            }
        }
    }
}
