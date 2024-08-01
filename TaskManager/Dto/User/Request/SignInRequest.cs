using System.ComponentModel.DataAnnotations;

namespace TaskManager.Dto.User.Request
{
    public class SignInRequest
    {
        [Required]
        public required string Email;
        [Required]
        public required string Password;
    }
}
