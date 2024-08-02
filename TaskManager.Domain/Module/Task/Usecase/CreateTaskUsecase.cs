using TaskManager.Domain.Module.Task.Model;
using TaskManager.Domain.Module.Task.Repository;

namespace TaskManager.Domain.Module.Task.Usecase;

public class CreateTaskUsecase
{
    private readonly ITaskRepository _taskRepository;

    public CreateTaskUsecase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskModel> Invoke(TaskModel taskModel)
    {
        return await _taskRepository.AddAsync(taskModel);
    }
}
