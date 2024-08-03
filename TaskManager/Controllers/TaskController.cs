using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Core.Module.Utils;
using TaskManager.Domain.Module.Task.Usecase;
using TaskManager.Dto;
using TaskManager.Dto.Task;
using TaskManager.Dto.Task.Request;
using TaskManager.Dto.Task.Response;

namespace TaskManager.Controllers;

[ApiController]
[Route("tasks")]
public class TaskController : ControllerBase
{
    private readonly CreateTaskUsecase _createTaskUsecase;
    private readonly AssignTaskUserUsecase _assignTaskUserUsecase;
    private readonly GetAllTasksUsecase _getAllTasksUsecase;
    private readonly GetTaskByIdUsecase _getTaskByIdUsecase;

    public TaskController(CreateTaskUsecase createTaskUsecase, AssignTaskUserUsecase assignTaskUserUsecase, GetAllTasksUsecase getAllTasksUsecase, GetTaskByIdUsecase getTaskByIdUsecase)
    {
        _createTaskUsecase = createTaskUsecase;
        _assignTaskUserUsecase = assignTaskUserUsecase;
        _getAllTasksUsecase = getAllTasksUsecase;
        _getTaskByIdUsecase = getTaskByIdUsecase;
    }

    [HttpGet]
    [Authorize(Roles = "ADMIN, EMPLOYEE")]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _getAllTasksUsecase.Invoke();
        return Ok(new DefaultResponse<List<TaskResponse>>(tasks.ToResponse()));
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> CreateTask(CreateTaskRequest request)
    {
        var taskModel = TaskDtoMapper.ToDomain(request);
        await _createTaskUsecase.Invoke(taskModel);
        return Ok(new DefaultResponse<Unit>("Tarefa criada com sucesso"));
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "ADMIN, EMPLOYEE")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var task = await _getTaskByIdUsecase.Invoke(id);
        return Ok(new DefaultResponse<TaskResponse>(task.ToResponse()));
    }

    [HttpPatch]
    [Authorize(Roles = "ADMIN, EMPLOYEE")]
    public async Task<IActionResult> AssignTaskUser(AssignTaskRequest request)
    {
        var task = await _assignTaskUserUsecase.Invoke(request.UserId, request.TaskId);
        return Ok(new DefaultResponse<TaskResponse>(task.ToResponse(), "Tarefa atribuída ao usuário com sucesso"));
    }
}
