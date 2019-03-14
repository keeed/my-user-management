using System;
using MyUserManagement.Core.Models;

namespace MyUserManagement.Core.Repositories
{
    public interface IUserRepository
    {
        User GetUser(User user);
    }
}