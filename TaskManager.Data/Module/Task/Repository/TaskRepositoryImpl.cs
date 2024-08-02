using TaskManager.Data.Module.Task.Mapper;
using TaskManager.Data.Module.UserTask.Repository;
using TaskManager.Domain.Module.Task.Model;
using TaskManager.Domain.Module.Task.Repository;

namespace TaskManager.Data.Module.Task.Repository;

public class TaskRepositoryImpl : ITaskRepository
{

    private readonly TaskLocalDataSource _taskLocalDataSource;

    public TaskRepositoryImpl(TaskLocalDataSource taskLocalDataSource)
    {
        _taskLocalDataSource = taskLocalDataSource;
    }

    public async Task<TaskModel> AddAsync(TaskModel task)
    {
        var insertedTask = await _taskLocalDataSource.AddTaskAsync(task.ToEntity());
        return insertedTask.ToDomain();
    }

    public async Task<TaskModel> AssignUserAsync(int userId, int taskId)
    {
        var updatedTask = await _taskLocalDataSource.AssignUserAsync(userId, taskId);
        return updatedTask.ToDomain();
    }

    public async Task<List<TaskModel>> GetAllAsync()
    {
        var tasks = await _taskLocalDataSource.GetAllAsync();
        return tasks.ToDomain();
    }

    public async Task<TaskModel> GetByIdAsync(int id)
    {
        var task = await _taskLocalDataSource.GetByIdAsync(id);
        return task.ToDomain();
    }
}
