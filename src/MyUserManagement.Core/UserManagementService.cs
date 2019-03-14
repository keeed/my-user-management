using System;
using MyUserManagement.Core.Models;
using MyUserManagement.Core.Repositories;

namespace MyUserManagement.Core
{
    public class UserManagementService
    {
        public UserManagementService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public IUserRepository UserRepository { get; }

        public bool Login(string username, string password)
        {
            User user = new User() 
            {
                Username = username,
                Password = password
            };

            var foundUser = UserRepository.GetUser(user);

            if (foundUser != null)
            {
                return true;
            }
            else
            {
                throw new Exception("Incorrect credentials!");
            }
        }
    }
}
