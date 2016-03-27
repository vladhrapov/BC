using System;
using System.Collections.Generic;
using System.Linq;
using BC.Data.Entity;
using BC.Data.Repository.Repository;

namespace BC.Services
{
    public class UserService : BaseService
    {
        private readonly IUserRepository UserRepository;

        public UserService()
        {
            UserRepository = new UserRepository(BaseService.GetContext());
        }

        public void AddUser(User user)
        {
            if (user.Password.Length < 8)
            {
                throw new ArgumentException("Login length less then 8 characters ");
            }

            if (UserRepository.All.Any(u => u.Login == user.Login))
            {
                throw new ArgumentException("User with name {0}, is already exist, choose another login", user.Login);
            }

            UserRepository.InsertOrUpdate(user);
        }

        public List<User> GetUsers()
        {
            return UserRepository.All.ToList();
        }

        public User GetUserById(Guid userId)
        {
            return UserRepository.Find(userId);
        }

        public void DeleteUser(Guid userId)
        {
            UserRepository.Delete(userId);
        }

        public void UpdateUser(User user)
        {
            if (user.Password.Length < 8)
            {
                throw new ArgumentException("Login length less then 8 characters ");
            }

            UserRepository.InsertOrUpdate(user);
        }
    }
}
