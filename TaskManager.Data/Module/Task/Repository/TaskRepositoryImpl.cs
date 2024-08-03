using AutoMapper;
using TaskManager.Data.Module.Task.DataSource;
using TaskManager.Data.Module.Task.Entity;
using TaskManager.Domain.Module.Task.Model;
using TaskManager.Domain.Module.Task.Repository;

namespace TaskManager.Data.Module.Task.Repository;

public class TaskRepositoryImpl : ITaskRepository
{

    private readonly ITaskLocalDataSource _taskLocalDataSource;
    private readonly IMapper _mapper;

    public TaskRepositoryImpl(ITaskLocalDataSource taskLocalDataSource, IMapper mapper)
    {
        _taskLocalDataSource = taskLocalDataSource;
        _mapper = mapper;
    }

    public async Task<TaskModel> AddAsync(TaskModel task)
    {
        var insertedTask = await _taskLocalDataSource.AddTaskAsync(_mapper.Map<TaskEntity>(task));
        return _mapper.Map<TaskModel>(insertedTask);
    }

    public async Task<TaskModel> AssignUserAsync(int userId, int taskId)
    {
        var updatedTask = await _taskLocalDataSource.AssignUserAsync(userId, taskId);
        return _mapper.Map<TaskModel>(updatedTask);
    }

    public async Task<List<TaskModel>> GetAllAsync()
    {
        var tasks = await _taskLocalDataSource.GetAllAsync();
        return _mapper.Map<List<TaskModel>>(tasks);
    }

    public async Task<TaskModel> GetByIdAsync(int id)
    {
        var task = await _taskLocalDataSource.GetByIdAsync(id);
        return _mapper.Map<TaskModel>(task);
    }
}
