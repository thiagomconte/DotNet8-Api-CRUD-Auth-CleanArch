using System.ComponentModel.DataAnnotations;

namespace TaskManager.Dto.Task.Request
{
    public class AssignTaskRequest
    {
        [Required]
        public required int UserId { get; set; }
        [Required]
        public required int TaskId { get; set; }
    }
}
