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
        public List<User> GetUsers()
        {
            return new UserService().GetUsers();
        }
    }
}
