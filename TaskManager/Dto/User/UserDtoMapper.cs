using TaskManager.Domain.Module.User.Model;
using TaskManager.Dto.Task;
using TaskManager.Dto.User.Request;
using TaskManager.Dto.User.Response;

namespace TaskManager.Dto.User
{
    public class UserDtoMapper
    {
        public static UserModel ToDomain(SignUpRequest request)
        {
            return new UserModel(request.Name, request.Email, request.Password);
        }

        public static UserResponse ToUserResponse(UserModel model)
        {
            var tasks = TaskDtoMapper.ToResponse(model.Tasks);
            return new UserResponse(model.Id, model.Name, model.Email, model.Role.ToString(), tasks);
        }
    }
}
