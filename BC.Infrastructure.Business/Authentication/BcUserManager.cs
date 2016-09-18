using BC.Domain.Core;
using BC.Infrastructure.Data;
using BC.Infrastructure.Data.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BC.Infrastructure.Business.Authentication
{
    public class BcUserManager : UserManager<User>
    {
        private static BcUserManager _userManager;
        private static Uow _uow;

        public BcUserManager(IUserStore<User> store) : base(store)
        {

        }

        private static void RegisterEmailService(string email, string confirmationLink)
        {
            _userManager.EmailService = new EmailService(email, confirmationLink);

            var provider = new DpapiDataProtectionProvider("Sample");

            _userManager.UserTokenProvider = new DataProtectorTokenProvider<User>(provider.Create())
            {
                //Code for email confirmation and reset password life time
                TokenLifespan = TimeSpan.FromHours(6),
            };
        }

        private static BcUserManager CreateUserManager(Uow uow)//IdentityFactoryOptions<BcUserManager> options, IOwinContext context)
        {
            ////var appDbContext = context.Get<BcContext>();
            ////var appUserManager = new BcUserManager(new UserStore<User>(appDbContext));

            //if (_userManager != null)
            //{
            //    return _userManager;
            //}
            //else if (uow != null)
            //{
            //    _userManager = new BcUserManager(new UserStore<User>(uow.GetContext()));
            //}
            //else
            //{
            //    _userManager = new BcUserManager(new UserStore<User>(BaseService.GetUow().GetContext()));
            //    //return CreateUserManager(BaseService.GetUow());
            //}

            ////_userManager = new BcUserManager(new UserStore<User>(uow.GetContext()));



            //return _userManager;

            _userManager = _userManager ?? new BcUserManager(new UserStore<User>(BaseService.GetUow().GetContext()));

            RegisterEmailService("", "");

            return _userManager;
        }

        private static BcUserManager CreateUserManager(string email, string confirmationLink)
        {
            _userManager = _userManager ?? CreateUserManager(BaseService.GetUow());

            RegisterEmailService(email, confirmationLink);

            return _userManager;
        }

        public static BcUserManager GetUserManager()
        {
            return CreateUserManager(BaseService.GetUow());
        }

        public static BcUserManager GetUserManager(string email, string confirmationLink)
        {
            return CreateUserManager(email, confirmationLink);
        }


    }
}
