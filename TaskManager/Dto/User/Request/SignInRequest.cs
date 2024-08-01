using System.ComponentModel.DataAnnotations;

namespace TaskManager.Dto.User.Request
{
    public class SignInRequest
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
