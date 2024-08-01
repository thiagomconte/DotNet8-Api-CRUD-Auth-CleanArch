using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskManager.Dto.User.Request
{
    public class SignUpRequest
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome não pode ter mais de 50 caracteres.")]
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress]
        [JsonPropertyName("email")]

        public required string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        [JsonPropertyName("password")]

        public required string Password { get; set; }
    }
}
