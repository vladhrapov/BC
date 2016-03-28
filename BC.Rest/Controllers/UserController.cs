using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BC.Data.Entity;
using BC.Services;

namespace BC.Rest.Controllers
{
    public class UserController : ApiController
    {
        public List<User> Users()
        {
            return new UserService().GetUsers();
        }

        public User User(int userId)
        {
            return new UserService().GetUserById(userId);
        }

        [HttpPost]
        public void AddUser(User user)
        {
            new UserService().AddUser(user);
        }

        [HttpDelete]
        public void Delete(int userId)
        {
            new UserService().DeleteUser(userId);
        }

        [HttpPut]
        public void UpdateUser(User user)
        {
            new UserService().UpdateUser(user);
        }
    }
}
