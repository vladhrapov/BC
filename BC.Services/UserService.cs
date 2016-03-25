using System;
using System.Collections.Generic;
using System.Linq;
using BC.Data.Entity;
using BC.Data.Entity.Enums;
using BC.Data.Repository;

namespace BC.Services
{
    public class UserService : BaseService
    {
        private readonly IUserRepository UserRepository;

        public UserService()
        {
            UserRepository = new UserRepository(BaseService.GetContext());
        }

        public void CreateUser(string login, string password)
        {
            if (password.Length < 8)
            {
                throw new ArgumentException("Login length less then 8 characters ");
            }

            if (UserRepository.GetUsers().Any(u => u.Login == login))
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

            UserRepository.AddUser(user);
        }

        public List<User> GetUsers()
        {
            return UserRepository.GetUsers().ToList();
        }
    }
}
