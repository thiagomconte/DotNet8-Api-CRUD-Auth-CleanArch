using TaskManager.Data.Module.Task.Mapper;
using TaskManager.Data.Module.User.Entity;
using TaskManager.Domain.Module.User.Model;

namespace TaskManager.Data.Module.User.Mapper
{
    public static class UserMapper
    {
        public static UserEntity ToEntity(this UserModel model)
        {
            return new UserEntity(model.Id, model.Name, model.Email, model.Password, model.Role);
        }

        public static List<UserEntity> ToEntity(this List<UserModel> models)
        {
            return models.Select(ToEntity).ToList();
        }

        public static UserModel ToDomain(this UserEntity entity)
        {
            return new UserModel(entity.Id, entity.Name, entity.Email, entity.Password, entity.Role);
        }

        public static List<UserModel> ToDomain(this List<UserEntity> entities)
        {
            return entities.Select(ToDomain).ToList();
        }
    }
}
