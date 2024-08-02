using TaskManager.Domain.Module.Task.Model;

namespace TaskManager.Domain.Module.Task.Repository;

public interface ITaskRepository
{
    public Task<List<TaskModel>> GetAllAsync();
    public Task<TaskModel> GetByIdAsync(int id);
    public Task<TaskModel> AddAsync(TaskModel task);
    public Task<TaskModel> AssignUserAsync(int userId, int taskId);
}
