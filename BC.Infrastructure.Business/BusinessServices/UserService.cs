using BC.Domain.Core;
using BC.Infrastructure.Data.Repository;
using BC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BC.Infrastructure.Business.BusinessServices
{
    public class UserService : BaseService, IService<User>
    {
        private readonly Uow _uow;

        public UserService()
        {
            this._uow = BaseService.GetUow();
        }

        public void Add(User user)
        {
            user.Id = Guid.NewGuid();
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

        public IEnumerable<User> GetAll()
        {
            return _uow.User.All.AsEnumerable<User>();
        }

        public User GetById(Guid id)
        {
            return _uow.User.Find(id);
        }

        public void Delete(Guid id)
        {
            _uow.User.Delete(id);
            _uow.Save();
        }

        public void Update(User user)
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
