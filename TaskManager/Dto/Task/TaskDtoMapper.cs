using TaskManager.Domain.Module.Task.Model;
using TaskManager.Dto.Task.Request;
using TaskManager.Dto.Task.Response;
using TaskManager.Dto.User;

namespace TaskManager.Dto.Task
{
    public static class TaskDtoMapper
    {
        public static TaskResponse ToResponse(this TaskModel model)
        {
            var userResponse = model.User != null ? model.User.ToUserResponse() : null;
            return new TaskResponse(model.Id, model.Title, model.Description, model.Status.ToString(), model.CreatedAt, userResponse);
        }

        public static List<TaskResponse> ToResponse(this List<TaskModel> models)
        {
            return models.Select(ToResponse).ToList();
        }

        public static TaskModel ToDomain(this CreateTaskRequest request)
        {
            return new TaskModel(request.Title, request.Description, request.Status, request.UserId);
        }
    }
}
