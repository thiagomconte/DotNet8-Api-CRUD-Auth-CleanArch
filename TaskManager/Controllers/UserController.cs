using Microsoft.AspNetCore.Mvc;
using TaskManager.Auth.Jwt;
using TaskManager.Domain.Module.User.Usecase;
using TaskManager.Dto;
using TaskManager.Dto.Auth;
using TaskManager.Dto.User;
using TaskManager.Dto.User.Request;
using TaskManager.Dto.User.Response;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly AddUserUsecase _addUserUsecase;
        private readonly GetUserByCredentialsUsecase _getUserByCredentialsUsecase;
        private readonly TokenUtils _tokenUtils;

        public UserController(ILogger<UserController> logger, AddUserUsecase addUserUsecase, GetUserByCredentialsUsecase getUserByCredentialsUsecase, TokenUtils tokenUtils)
        {
            _logger = logger;
            _addUserUsecase = addUserUsecase;
            _getUserByCredentialsUsecase = getUserByCredentialsUsecase;
            _tokenUtils = tokenUtils;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpRequest request)
        {
            var createdUser = await _addUserUsecase.Invoke(UserDtoMapper.ToDomain(request));
            var response = UserDtoMapper.ToUserResponse(createdUser);
            return Ok(new DefaultResponse<UserResponse>("Cadastro realizado com sucesso"));
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            var existingUser = await _getUserByCredentialsUsecase.Invoke(request.Email, request.Password);
            var userResponse = UserDtoMapper.ToUserResponse(existingUser);
            var token = _tokenUtils.GenerateToken(userResponse);
            var authResponse = new AuthResponse(userResponse, token);
            return Ok(new DefaultResponse<AuthResponse>(authResponse, "Login realizado com sucesso"));
        }
    }
}
