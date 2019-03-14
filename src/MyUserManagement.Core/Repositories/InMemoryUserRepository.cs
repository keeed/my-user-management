using System;
using MyUserManagement.Core.Models;

namespace MyUserManagement.Core.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        public User GetUser(User user)
        {
            if (user.Username == "admin" && user.Password == "admin")
            {
                return user;
            }

            return null;
        }
    }
}