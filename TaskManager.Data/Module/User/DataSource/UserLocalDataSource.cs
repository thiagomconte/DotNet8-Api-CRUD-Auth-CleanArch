using TaskManager.Data.Module.User.Repository;

namespace TaskManager.Data.Module.User.DataSource
{
    using Microsoft.EntityFrameworkCore;
    using TaskManager.Core.Module.Exceptions;
    using TaskManager.Data.Module.Database;
    using TaskManager.Data.Module.User.Entity;

    public class UserLocalDataSource : IUserLocalDataSource
    {

        private readonly TaskManagerDbContext _dbContext;

        public UserLocalDataSource(TaskManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserEntity> AddUserAsync(UserEntity user)
        {
            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<UserEntity>> GetUsersAsync()
        {
            return await _dbContext.User.AsNoTracking().ToListAsync();
        }

        public async Task<UserEntity> GetUserByIdAsync(int id)
        {
            return await _dbContext.User.FindAsync(id) ?? throw new EntityNotFoundException("Usuário não encontrado");
        }

        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _dbContext.User.Where(u => u.Email == email).FirstOrDefaultAsync() ?? throw new EntityNotFoundException("Usuário não encontrado");
        }
    }
}
