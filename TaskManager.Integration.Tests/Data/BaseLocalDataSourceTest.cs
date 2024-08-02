using Microsoft.EntityFrameworkCore;
using TaskManager.Data.Module.Database;
using Xunit;

namespace TaskManager.Integration.Tests.Data
{
    public class BaseLocalDataSourceTest
    {

        protected DbContextOptions<TaskManagerDbContext> _options;
        public TaskManagerDbContext _context;

        protected void SetupDb()
        {

            _options = new DbContextOptionsBuilder<TaskManagerDbContext>()
                        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                        .Options;

            _context = new TaskManagerDbContext(_options);
        }
    }
}
