using Microsoft.AspNetCore.Authorization;
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
    [Route("users")]
    public class UserController : ControllerBase
    {

        private readonly AddUserUsecase _addUserUsecase;
        private readonly GetUserByCredentialsUsecase _getUserByCredentialsUsecase;
        private readonly GetAllUsersUsecase _getAllUsersUsecase;
        private readonly TokenUtils _tokenUtils;

        public UserController(AddUserUsecase addUserUsecase, GetUserByCredentialsUsecase getUserByCredentialsUsecase, TokenUtils tokenUtils, GetAllUsersUsecase getAllUsersUsecase)
        {
            _addUserUsecase = addUserUsecase;
            _getUserByCredentialsUsecase = getUserByCredentialsUsecase;
            _tokenUtils = tokenUtils;
            _getAllUsersUsecase = getAllUsersUsecase;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpRequest request)
        {
            var createdUser = await _addUserUsecase.Invoke(request.ToDomain());
            return Ok(new DefaultResponse<UserResponse>(createdUser.ToUserResponse(), "Cadastro realizado com sucesso"));
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            var existingUser = await _getUserByCredentialsUsecase.Invoke(request.Email, request.Password);
            var userResponse = existingUser.ToUserResponse();
            var token = _tokenUtils.GenerateToken(userResponse);
            var authResponse = new AuthResponse(userResponse, token);
            return Ok(new DefaultResponse<AuthResponse>(authResponse, "Login realizado com sucesso"));
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _getAllUsersUsecase.Invoke();
            return Ok(new DefaultResponse<List<UserResponse>>(users.ToUserResponse()));
        }
    }
}
