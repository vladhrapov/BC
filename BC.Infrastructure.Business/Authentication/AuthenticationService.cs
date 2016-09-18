using BC.Domain.Core;
using BC.Infrastructure.Data.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BC.Infrastructure.Business.Authentication
{
    public class AuthenticationService : BaseService
    {
        private readonly BcUserManager _userManager;

        public AuthenticationService()
        {
            this._userManager = BcUserManager.GetUserManager();
        }

        public IEnumerable<User> All()
        {
            return this._userManager.Users.ToList<User>();
        }

        public User FindById(string id)
        {
            return this._userManager.FindById(id);
        }

        public User FindByName(string username)
        {
            return this._userManager.FindByName(username);
        }

        public IdentityResult Add(User user, string password)
        {
            IdentityResult result = this._userManager.Create(user, password);

            if (result.Succeeded)
            {
                this._userManager.AddToRole(user.Id, "user");
            }

            return result;
        }

        // 
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, UserManager<User> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(user, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
