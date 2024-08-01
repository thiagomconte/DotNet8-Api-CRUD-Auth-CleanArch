using TaskManager.Domain.Module.Task.Model;
using TaskManager.Dto.Task.Response;
using TaskManager.Dto.User;

namespace TaskManager.Dto.Task
{
    public class TaskDtoMapper
    {
        public static TaskResponse ToResponse(TaskModel model)
        {
            var userResponse = model.User == null ? UserDtoMapper.ToUserResponse(model.User) : null;
            return new TaskResponse(model.Id, model.Title, model.Description, model.Status.ToString(), model.CreatedAt, userResponse);
        }

        public static List<TaskResponse> ToResponse(List<TaskModel> models)
        {
            return models.Select(ToResponse).ToList();
        }
    }
}
