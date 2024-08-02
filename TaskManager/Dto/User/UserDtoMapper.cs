using TaskManager.Domain.Module.User.Model;
using TaskManager.Dto.Task;
using TaskManager.Dto.User.Request;
using TaskManager.Dto.User.Response;

namespace TaskManager.Dto.User
{
    public static class UserDtoMapper
    {
        public static UserModel ToDomain(this SignUpRequest request)
        {
            return new UserModel(request.Name, request.Email, request.Password);
        }

        public static UserResponse ToUserResponse(this UserModel model)
        {
            return new UserResponse(model.Id, model.Name, model.Email, model.Role.ToString());
        }

        public static List<UserResponse> ToUserResponse(this List<UserModel> models)
        {
            return models.Select(ToUserResponse).ToList();
        }
    }
}
