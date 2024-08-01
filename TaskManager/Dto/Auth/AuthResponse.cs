using TaskManager.Dto.User.Response;

namespace TaskManager.Dto.Auth
{
    public class AuthResponse(UserResponse user, string token)
    {
        public UserResponse User { get; set; } = user;
        public string Token { get; set; } = token;
    }
}
