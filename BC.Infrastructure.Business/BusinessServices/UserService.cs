using BC.Domain.Core;
using BC.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BC.Infastructure.Interfaces;

namespace BC.Infrastructure.Business.BusinessServices
{
    public class UserService : BaseService, IService<User>
    {
        private readonly Uow _uow;

        public UserService()
        {
            this._uow = BaseService.GetUow();
        }

        public IEnumerable<User> All()
        {
            throw new NotImplementedException();
        }

        public User FindBy(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(User user)
        {
            //TODO Delete IT
            //user.Id = Guid.NewGuid();
            //if (user.Password.Length < 8)
            //{
            //    throw new ArgumentException("Login length less then 8 characters ");
            //}

            //if (_uow.User.All.Any(u => u.Login == user.Login))
            //{
            //    throw new ArgumentException("User with name {0}, is already exist, choose another login", user.Login);
            //}

            //_uow.User.InsertOrUpdate(user);
            //_uow.Save();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
            _uow.Save();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
