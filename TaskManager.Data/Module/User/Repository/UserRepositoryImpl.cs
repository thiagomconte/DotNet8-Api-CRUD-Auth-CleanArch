using AutoMapper;
using TaskManager.Data.Module.User.Entity;
using TaskManager.Domain.Module.User.Model;
using TaskManager.Domain.Module.User.Repository;

namespace TaskManager.Data.Module.User.Repository
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly IUserLocalDataSource _dataSource;
        private readonly IMapper _mapper;

        public UserRepositoryImpl(IUserLocalDataSource dataSource, IMapper mapper)
        {
            _dataSource = dataSource;
            _mapper = mapper;
        }

        public async Task<UserModel> AddUserAsync(UserModel user)
        {
            var insertedUser = await _dataSource.AddUserAsync(_mapper.Map<UserEntity>(user));
            return _mapper.Map<UserModel>(insertedUser);
        }

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            var user = await _dataSource.GetUserByEmailAsync(email);
            return _mapper.Map<UserModel>(user);
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var user = await _dataSource.GetUserByIdAsync(id);
            return _mapper.Map<UserModel>(user);
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            var users = await _dataSource.GetUsersAsync();
            return _mapper.Map<List<UserModel>>(users);
        }
    }
}
