using TaskManager.Domain.Module.Task.Model;

namespace TaskManager.Domain.Module.User.Model
{
    public class UserModel(int id, string name, string email, string password, UserRole role, List<TaskModel>? tasks)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;
        public UserRole role { get; set; } = role;
        public List<TaskModel> Tasks { get; set; } = tasks ?? [];
    }
}
