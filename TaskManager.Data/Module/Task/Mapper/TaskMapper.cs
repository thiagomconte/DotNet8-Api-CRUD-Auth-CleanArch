using TaskManager.Data.Module.Task.Entity;
using TaskManager.Data.Module.User.Entity;
using TaskManager.Data.Module.User.Mapper;
using TaskManager.Domain.Module.Task.Model;
using TaskManager.Domain.Module.User.Model;

namespace TaskManager.Data.Module.Task.Mapper
{
    public class TaskMapper
    {
        public static TaskEntity ToEntity(TaskModel model)
        {
            UserEntity? user = model.User != null ? UserMapper.ToEntity(model.User) : null;
            return new TaskEntity(model.Id, model.Title, model.Description, model.Status, model.CreatedAt, model.UserId, user);
        }

        public static List<TaskEntity> ToEntity(List<TaskModel> models)
        {
            return models.Select(ToEntity).ToList();
        }

        public static TaskModel ToDomain(TaskEntity entity)
        {
            UserModel? user = entity.User != null ? UserMapper.ToDomain(entity.User) : null;
            return new TaskModel(entity.Id, entity.Title, entity.Description, entity.Status, entity.CreatedAt, entity.UserId, user);
        }

        public static List<TaskModel> ToDomain(List<TaskEntity> entities)
        {
            return entities.Select(ToDomain).ToList();
        }
    }
}
