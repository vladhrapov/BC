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
        //public List<User> Users()
        //{
        //    return new UserService().GetUsers().ToList();
        //}
        
        [HttpGet]
        public HttpResponseMessage Users()
        {
            var users = new UserService().GetUsers().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpGet]
        public User User(Guid id)
        {
            return new UserService().GetUserById(id);
        }

        [HttpPost]
        public void AddUser(User user)
        {
            new UserService().AddUser(user);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            new UserService().DeleteUser(id);
        }

        [HttpPut]
        public void UpdateUser(User user)
        {
            new UserService().UpdateUser(user);
        }
    }
}
