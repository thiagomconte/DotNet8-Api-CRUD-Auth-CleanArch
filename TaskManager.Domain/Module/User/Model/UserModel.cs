using TaskManager.Domain.Module.Task.Model;

namespace TaskManager.Domain.Module.User.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.EMPLOYEE;
        public List<TaskModel> Tasks { get; set; } = [];

        public UserModel(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public UserModel(int id, string name, string email, string password, UserRole role, List<TaskModel>? tasks)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            Tasks = tasks ?? [];
        }
    }
}
