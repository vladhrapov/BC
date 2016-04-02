using System;
using System.Collections.Generic;
using System.Linq;
using BC.Data.Entity;
using BC.Data.Repository.Repository;

namespace BC.Services
{
    public class UserService : BaseService
    {
        private readonly Uow _uow;

        public UserService()
        {
            this._uow = BaseService.GetUow();
        }

        public void AddUser(User user)
        {
            if (user.Password.Length < 8)
            {
                throw new ArgumentException("Login length less then 8 characters ");
            }

            if (_uow.User.All.Any(u => u.Login == user.Login))
            {
                throw new ArgumentException("User with name {0}, is already exist, choose another login", user.Login);
            }

            _uow.User.InsertOrUpdate(user);
            _uow.Save();
        }

        public IEnumerable<User> GetUsers()
        {
            return _uow.User.All.AsEnumerable<User>();
        }

        public User GetUserById(Guid id)
        {
            return _uow.User.Find(id);
        }

        public void DeleteUser(Guid id)
        {
            _uow.User.Delete(id);
            _uow.Save();
        }

        public void UpdateUser(User user)
        {
            if (user.Password.Length < 8)
            {
                throw new ArgumentException("Login length less then 8 characters ");
            }

            _uow.User.InsertOrUpdate(user);
            _uow.Save();
        }
    }
}
