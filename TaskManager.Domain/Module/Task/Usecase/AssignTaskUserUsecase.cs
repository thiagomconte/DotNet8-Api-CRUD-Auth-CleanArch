using TaskManager.Domain.Module.Task.Model;
using TaskManager.Domain.Module.Task.Repository;

namespace TaskManager.Domain.Module.Task.Usecase;

public class AssignTaskUserUsecase
{
    private readonly ITaskRepository _taskRepository;

    public AssignTaskUserUsecase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskModel> Invoke(int userId, int taskId)
    {
        return await _taskRepository.AssignUserAsync(userId, taskId);
    }
}
