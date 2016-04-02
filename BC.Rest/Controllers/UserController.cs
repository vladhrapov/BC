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
        public List<User> Get()
        {
            return new UserService().GetUsers().ToList();
        }

        [HttpGet]
        public User Get(Guid id)
        {
            return new UserService().GetUserById(id);
        }

        [HttpPost]
        public void Add(User user)
        {
            new UserService().AddUser(user);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            new UserService().DeleteUser(id);
        }

        [HttpPut]
        public void Update(User user)
        {
            new UserService().UpdateUser(user);
        }
    }
}
