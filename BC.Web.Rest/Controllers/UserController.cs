using BC.Domain.Core;
using BC.Infrastructure.Business.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BC.Web.Rest.Controllers
{
    public class UserController : ApiController
    {
        public List<User> Get()
        {
            return new UserService().GetAll().ToList();
        }

        [HttpGet]
        public User Get(Guid id)
        {
            return new UserService().GetById(id);
        }

        [HttpPost]
        public void Add(User user)
        {
            new UserService().Add(user);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            new UserService().Delete(id);
        }

        [HttpPut]
        public void Update(User user)
        {
            new UserService().Update(user);
        }
    }
}
