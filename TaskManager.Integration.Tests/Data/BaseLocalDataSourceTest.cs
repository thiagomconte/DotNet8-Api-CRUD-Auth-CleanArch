using Microsoft.EntityFrameworkCore;
using TaskManager.Data.Module.Database;

namespace TaskManager.Integration.Tests.Data
{
    public class BaseLocalDataSourceTest
    {

        protected DbContextOptions<TaskManagerDbContext> _options;
        protected TaskManagerDbContext _context;

        protected void SetupDb()
        {

            _options = new DbContextOptionsBuilder<TaskManagerDbContext>()
                        .UseInMemoryDatabase(databaseName: "TaskManagerTestDb")
                        .Options;

            _context = new TaskManagerDbContext(_options);
        }
    }
}
