using DotMenu.Models;

namespace DotMenu.Services
{
    public interface IAuthService
    {
        public string GenerateToken(User user);
    }
}