using System.Collections.Generic;
using System.Linq;
using DotMenu.Models;

namespace DotMenu.Repositories
{
    public class UserRepository
    {
        public static User Get(string email, string password)
        {
            var users = new List<User>
            {
                new User {Id = 1, Email = "jrafaeldesantana@gmail.com", Name = "Rafael", Password = "12345"},
                new User {Id = 2, Email = "joserafael.santana22@gmail.com", Name = "Rafael 2", Password = "12345"}
            };
            
            return users.FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()) && x.Password == password);
        }
    }
}