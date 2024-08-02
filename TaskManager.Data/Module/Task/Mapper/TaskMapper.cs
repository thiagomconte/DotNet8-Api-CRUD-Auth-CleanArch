using TaskManager.Data.Module.Task.Entity;
using TaskManager.Data.Module.User.Entity;
using TaskManager.Data.Module.User.Mapper;
using TaskManager.Domain.Module.Task.Model;
using TaskManager.Domain.Module.User.Model;

namespace TaskManager.Data.Module.Task.Mapper
{
    public static class TaskMapper
    {
        public static TaskEntity ToEntity(this TaskModel model)
        {
            UserEntity? user = model.User != null ? model.User.ToEntity() : null;
            return new TaskEntity(model.Id, model.Title, model.Description, model.Status, model.CreatedAt, model.UserId, user);
        }

        public static List<TaskEntity> ToEntity(this List<TaskModel> models)
        {
            return models.Select(ToEntity).ToList();
        }

        public static TaskModel ToDomain(this TaskEntity entity)
        {
            UserModel? user = entity.User != null ? entity.User.ToDomain() : null;
            return new TaskModel(entity.Id, entity.Title, entity.Description, entity.Status, entity.CreatedAt, entity.UserId, user);
        }

        public static List<TaskModel> ToDomain(this List<TaskEntity> entities)
        {
            return entities.Select(ToDomain).ToList();
        }
    }
}
