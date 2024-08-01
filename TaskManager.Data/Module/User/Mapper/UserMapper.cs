using TaskManager.Data.Module.Task.Mapper;
using TaskManager.Data.Module.User.Entity;
using TaskManager.Domain.Module.User.Model;

namespace TaskManager.Data.Module.User.Mapper
{
    public class UserMapper
    {
        public static UserEntity ToEntity(UserModel model)
        {
            var tasks = TaskMapper.ToEntity(model.Tasks);
            return new UserEntity(model.Id, model.Name, model.Email, model.Password, model.role, tasks);
        }

        public static List<UserEntity> ToEntity(List<UserModel> models)
        {
            return models.Select(ToEntity).ToList();
        }
    }
}
