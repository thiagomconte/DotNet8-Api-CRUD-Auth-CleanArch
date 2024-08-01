using System.ComponentModel.DataAnnotations;

namespace TaskManager.Dto.User.Request
{
    public class SignUpRequest
    {
        [Required]
        public required string Name;
        [Required]
        public required string Email;
        [Required]
        public required string Password;
    }
}
