//using BC.Domain.Core;
//using BC.Infrastructure.Data.Repository;
//using System;
//using System.Collections.Generic;
//using System.Linq.Expressions;
//using BC.Infastructure.Interfaces;
//using BC.Infrastructure.Business.Authentication;
//using Microsoft.AspNet.Identity;
//using System.Linq;

//namespace BC.Infrastructure.Business.BusinessServices
//{
//    public class UserService : BaseService, IService<User>
//    {
//        private readonly Uow _uow;
//        private readonly BcUserManager _userManager;

//        public UserService()
//        {
//            this._uow = BaseService.GetUow();
//            this._userManager = BcUserManager.GetUserManager(this._uow);
//        }

//        public IEnumerable<User> All()
//        {
//            return this._userManager.Users.ToList<User>();
//        }

//        public User FindById(string id)
//        {
//            return this._userManager.FindById(id);
//        }

//        public User FindByName(string username)
//        {
//            return this._userManager.FindByName(username);
//        }

//        public IdentityResult Add(User user, string password)
//        {
//            IdentityResult result = this._userManager.Create(user, password);

//            if (result.Succeeded)
//            {
//                this._userManager.AddToRole(user.Id, "user");
//            }

//            return result;
//        }


//        public User FindBy(Expression<Func<User, bool>> predicate)
//        {
//            throw new NotImplementedException();
//            //return _userManager.Fi //_uow. //.FindBy(predicate);
//        }

//        public void Add(User user)
//        {
//            //TODO Delete IT
//            //user.Id = Guid.NewGuid();
//            //if (user.Password.Length < 8)
//            //{
//            //    throw new ArgumentException("Login length less then 8 characters ");
//            //}

//            //if (_uow.User.All.Any(u => u.Login == user.Login))
//            //{
//            //    throw new ArgumentException("User with name {0}, is already exist, choose another login", user.Login);
//            //}

//            //_uow.User.InsertOrUpdate(user);
//            //_uow.Save();
//        }

//        public IEnumerable<User> GetAll()
//        {
//            throw new NotImplementedException();
//        }

//        public User GetById(Guid id)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(Guid id)
//        {
//            throw new NotImplementedException();
//            _uow.Save();
//        }

//        public void Update(User user)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
