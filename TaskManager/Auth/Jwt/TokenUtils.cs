namespace TaskManager.Auth.Jwt
{
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using TaskManager.Core.Module.Exceptions;
    using TaskManager.Dto.User.Response;

    public class TokenUtils
    {

        private readonly IConfiguration _configuration;

        public TokenUtils(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(UserResponse userResponse)
        {
            var jwtSettings = _configuration.GetSection("Jwt").Get<JwtSettings>() ?? throw new InvalidJwtSettingsException();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([new Claim(ClaimTypes.NameIdentifier, userResponse.Id.ToString()), new Claim(ClaimTypes.Role, userResponse.Role.ToString())]),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = jwtSettings.Issuer,
                Audience = jwtSettings.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
