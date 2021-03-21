using DotMenu.Dtos;
using DotMenu.Repositories;
using DotMenu.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotMenu.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Authenticate([FromBody] UserDto model)
        {
            var user = UserRepository.Get(model.Email, model.Password);

            if (user == null)
                return NotFound(new { message = "Login ou senha incorretos" });

            var token = _authService.GenerateToken(user);
            
            return Ok(new { user, token });
        }
    }
}