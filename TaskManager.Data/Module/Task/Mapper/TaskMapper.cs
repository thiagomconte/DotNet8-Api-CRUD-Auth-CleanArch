using TaskManager.Data.Module.Task.Entity;
using TaskManager.Data.Module.User.Entity;
using TaskManager.Data.Module.User.Mapper;
using TaskManager.Domain.Module.Task.Model;

namespace TaskManager.Data.Module.Task.Mapper
{
    public class TaskMapper
    {
        public static TaskEntity ToEntity(TaskModel model)
        {
            UserEntity? user = model.User != null ? UserMapper.ToEntity(model.User) : null;
            return new TaskEntity(model.Id, model.Title, model.Title, model.Status, model.CreatedAt, model.UserId, user);
        }

        public static List<TaskEntity> ToEntity(List<TaskModel> models)
        {
            return models.Select(ToEntity).ToList();
        }
    }
}
