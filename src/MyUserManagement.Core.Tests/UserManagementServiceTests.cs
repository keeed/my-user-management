using System;
using Moq;
using MyUserManagement.Core.Models;
using MyUserManagement.Core.Repositories;
using Xunit;

namespace MyUserManagement.Core.Tests
{
    public class UserManagementServiceTests
    {
        [Fact]
        public void Should_Return_True_When_User_Is_Authenticated()
        {
            // Given:
            string username = "admin";

            // And:
            string password = "admin";

            // And:
            var userRepository = new Mock<IUserRepository>();

            // And:
            userRepository
                .Setup( r => r.GetUser(It.IsAny<User>()))
                .Returns( new User());

            // And:
            UserManagementService sut = new UserManagementService(userRepository.Object);

            // When:
            bool isLoggedIn = sut.Login(username, password);

            // Then:
            Assert.Equal(true, isLoggedIn);
        }
        
        [Fact]
        public void Should_Throw_Exception_When_User_Is_Not_Authenticated()
        {
            // Given:
            string username = "admin";

            // And:
            string password = "notadmin";

            // And:
            var userRepository = new Mock<IUserRepository>();

            // And:
            userRepository
                .Setup( r => r.GetUser(It.IsAny<User>()))
                .Returns(() => null);

            // And:
            UserManagementService sut = new UserManagementService(userRepository.Object);

            // When:
            Action action = () => sut.Login(username, password);

            // Then:
            Assert.Throws<Exception>(action);
        }
    }

    // internal class TestUserRepository : IUserRepository
    // {
    //     public User GetUser(User user)
    //     {
    //         if (user.Username == "admin" && user.Password == "admin")
    //         {
    //             return user;
    //         }

    //         return null;
    //     }
    // }
}
