using TaskManager.Data.Module.Task.Entity;

namespace TaskManager.Data.Module.Task.DataSource
{
    public interface ITaskLocalDataSource
    {

        public Task<List<TaskEntity>> GetAllAsync();

        public Task<TaskEntity> GetByIdAsync(int id);

        public Task<TaskEntity> AddTaskAsync(TaskEntity task);

        public Task<TaskEntity> AssignUserAsync(int userId, int taskId);
    }
}
