using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Module.User.Model;

namespace TaskManager.Domain.Module.Task.Model
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public UserTaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? UserId { get; set; }
        public UserModel? User { get; set; }

        public TaskModel(int id, string title, string description, UserTaskStatus status, DateTime createdAt, int? userId, UserModel? user)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
            CreatedAt = createdAt;
            UserId = userId;
            User = user;
        }

        public TaskModel(string title, string description, UserTaskStatus status, int? userId)
        {
            Title = title;
            Description = description;
            Status = status;
            UserId = userId;
        }
    }
}
