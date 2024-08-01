using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Module.User.Model;

namespace TaskManager.Domain.Module.User.Repository
{
    public interface IUserRepository
    {
        public Task<UserModel> AddUserAsync(UserModel user);
        public Task<List<UserModel>> GetUsersAsync();
        public Task<List<UserModel>> GetUserByIdAsync(int id);
        public Task<List<UserModel>> GetUserByEmailAsync(string email);
    }
}
