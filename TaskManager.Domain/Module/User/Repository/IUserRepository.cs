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
        public Task<UserModel> GetUserByIdAsync(int id);
        public Task<UserModel> GetUserByEmailAsync(string email);
    }
}
