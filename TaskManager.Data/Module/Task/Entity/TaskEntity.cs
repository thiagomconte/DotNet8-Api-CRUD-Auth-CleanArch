using System.ComponentModel.DataAnnotations;
using TaskManager.Data.Module.User.Entity;
using TaskManager.Domain.Module.Task.Model;

namespace TaskManager.Data.Module.Task.Entity
{
    public class TaskEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(60)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public UserTaskStatus Status { get; set; } = UserTaskStatus.PENDING;
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? UserId { get; set; }
        public UserEntity? User { get; set; }

        public TaskEntity() { }

        public TaskEntity(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public TaskEntity(int id, string title, string description, UserTaskStatus status, DateTime createdAt, int? userId, UserEntity? user)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
            CreatedAt = createdAt;
            UserId = userId;
            User = user;
        }
    }
}
