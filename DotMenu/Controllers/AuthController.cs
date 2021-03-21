using DotMenu.Models;
using DotMenu.Repositories;
using DotMenu.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotMenu.Controllers
{
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Authenticate([FromBody] User model)
        {
            var user = UserRepository.Get(model.Email, model.Password);

            if (user == null)
                return NotFound("Login ou senha incorretos");

            var token = AuthService.GenerateToken(user);
            
            return Ok(new {
                user = user,
                token = token
            });
        }
    }
}