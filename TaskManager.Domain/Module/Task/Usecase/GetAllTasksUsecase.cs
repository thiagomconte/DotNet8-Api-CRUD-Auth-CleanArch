using TaskManager.Domain.Module.Task.Model;
using TaskManager.Domain.Module.Task.Repository;

namespace TaskManager.Domain.Module.Task.Usecase;

public class GetAllTasksUsecase
{
    private readonly ITaskRepository _taskRepository;

    public GetAllTasksUsecase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<List<TaskModel>> Invoke()
    {
        return await _taskRepository.GetAllAsync();
    }
}
