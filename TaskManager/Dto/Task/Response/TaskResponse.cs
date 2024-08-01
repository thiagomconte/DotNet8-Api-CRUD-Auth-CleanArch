using TaskManager.Dto.User.Response;

namespace TaskManager.Dto.Task.Response
{
    public class TaskResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserResponse? User { get; set; }

        public TaskResponse(int id, string title, string description, string status, DateTime createdAt, UserResponse? user)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
            CreatedAt = createdAt;
            User = user;
        }
    }
}
