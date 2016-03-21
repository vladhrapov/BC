using System;
using System.Collections.Generic;
using System.Linq;
using BC.Data.Entity;
using BC.Data.Repository;

namespace BC.Services
{
    public static class UserService
    {
        private static readonly IUserRepository userRepository;

        static UserService()
        {
            userRepository = new UserRepository(new BcContext());
        }

        public static void CreateUser(string login, string password)
        {
            if (password.Length < 8)
            {
                throw new ArgumentException("Login length less then 8 characters ");
            }
            if (userRepository.GetUsers().Any(u => u.Login == login))
            {
                throw new ArgumentException("User with name {0}, is already exist, choose another login", login);
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Login = login,
                Password = password,
                UserType = UserType.User
            };

            userRepository.AddUser(user);
        }

        public static List<User> GetUsers()
        {
            return userRepository.GetUsers().ToList();
        }
    }
}
