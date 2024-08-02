using TaskManager.Domain.Module.Task.Model;
using TaskManager.Domain.Module.Task.Repository;

namespace TaskManager.Domain.Module.Task.Usecase;

public class GetTaskByIdUsecase
{
    private readonly ITaskRepository _taskRepository;

    public GetTaskByIdUsecase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskModel> Invoke(int id)
    {
        return await _taskRepository.GetByIdAsync(id);
    }
}
