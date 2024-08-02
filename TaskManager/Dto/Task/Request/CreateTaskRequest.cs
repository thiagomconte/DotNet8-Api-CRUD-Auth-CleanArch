using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaskManager.Domain.Module.Task.Model;

namespace TaskManager.Dto.Task.Request;

public class CreateTaskRequest
{
    [Required]
    [MinLength(5)]
    [MaxLength(60)]
    [JsonPropertyName("title")]
    public required string Title { get; set; }
    [MaxLength(250)]
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    public UserTaskStatus Status { get; set; } = UserTaskStatus.PENDING;
    [JsonPropertyName("userId")]
    public int? UserId { get; set; }
}
