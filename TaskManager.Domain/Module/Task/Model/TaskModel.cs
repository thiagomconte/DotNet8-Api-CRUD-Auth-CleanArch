using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Module.User.Model;

namespace TaskManager.Domain.Module.Task.Model
{
    public class TaskModel(int id, string title, string description, UserTaskStatus status, int? userId, UserModel? user)
    {
        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        public string Description { get; set; } = description;
        public UserTaskStatus Status { get; set; } = status;
        public DateTime CreatedAt { get; set; }
        public int? UserId { get; set; } = userId;
        public UserModel? User { get; set; } = user;
    }
}
