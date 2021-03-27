using System.Threading.Tasks;
using DotMenu.Models;

namespace DotMenu.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmail(string email);
    }
}