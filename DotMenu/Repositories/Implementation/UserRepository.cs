using System.Threading.Tasks;
using DotMenu.Models;
using DotMenu.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace DotMenu.Repositories.Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DotmenuDBContext dotmenuDbContext) : base(dotmenuDbContext)
        {
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<User> GetUserByEmail(string email)
        {
            return GetAll().FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}