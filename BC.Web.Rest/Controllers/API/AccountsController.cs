using BC.Domain.Core;
using BC.Infrastructure.Business.Authentication;
using BC.Web.Rest.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace BC.Web.Rest.Controllers.API
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : ApiController
    {
        //public string Id { get; set; }
        //public string UserName { get; set; }
        //public string FullName { get; set; }
        //public string Email { get; set; }
        //public bool EmailConfirmed { get; set; }
        //public DateTime JoinDate { get; set; }
        //public IList<string> Roles { get; set; }
        //public IList<System.Security.Claims.Claim> Claims { get; set; }

        [Authorize(Roles = "admin")]
        [Route("users")]
        public IHttpActionResult GetUsers()
        {
            return Ok(new AuthenticationService().All().Select(user => new UserReturnModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                FullName = String.Format("{0} {1}", user.FirstName, user.LastName),
                Email = user.Email,
                Roles = BcUserManager.GetUserManager().GetRoles(user.Id),
                Claims = BcUserManager.GetUserManager().GetClaims(user.Id)
            }));
            //return Ok(this.AppUserManager.Users.ToList().Select(u => this.TheModelFactory.Create(u)));
        }

        [Authorize(Roles = "admin")]
        [Route("user/{id:guid}", Name = "GetUserById")]
        public IHttpActionResult GetUser(string id)
        {
            var user = new AuthenticationService().FindById(id);//await this.AppUserManager.FindByIdAsync(Id);

            if (user != null)
            {
                return Ok(new UserReturnModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    FullName = String.Format("{0} {1}", user.FirstName, user.LastName),
                    Email = user.Email,
                    Roles = BcUserManager.GetUserManager().GetRoles(user.Id),
                    Claims = BcUserManager.GetUserManager().GetClaims(user.Id)
                });
                //return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }

        [Authorize(Roles = "admin")]
        [Route("user/{username}")]
        public IHttpActionResult GetUserByName(string username)
        {
            var user = new AuthenticationService().FindByName(username);// await this.AppUserManager.FindByNameAsync(username);

            if (user != null)
            {
                return Ok(new UserReturnModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    FullName = String.Format("{0} {1}", user.FirstName, user.LastName),
                    Email = user.Email,
                    Roles = BcUserManager.GetUserManager().GetRoles(user.Id),
                    Claims = BcUserManager.GetUserManager().GetClaims(user.Id)
                });
            }

            return NotFound();

        }

        [HttpPost]
        [Route("create")]
        public async Task<IHttpActionResult> CreateUser([FromBody]CreateUserBindingModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User()
            {
                UserName = createUserModel.Username,
                Email = createUserModel.Email,
                FirstName = createUserModel.FirstName,
                LastName = createUserModel.LastName,
                JoinDate = DateTime.Now.Date,
            };

            IdentityResult addUserResult = new AuthenticationService().Add(user, createUserModel.Password);//await this.AppUserManager.CreateAsync(user, createUserModel.Password);

            if (!addUserResult.Succeeded)
            {
                return GetErrorResult(addUserResult);
            }

            //Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));


            string code = await BcUserManager.GetUserManager().GenerateEmailConfirmationTokenAsync(user.Id);

            var callbackUrl = new Uri(Url.Link("ConfirmEmailRoute", new { userId = user.Id, code = code }));

            await BcUserManager.GetUserManager(createUserModel.Email, callbackUrl.ToString()).SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");


            return Ok();//Created(locationHeader, TheModelFactory.Create(user));
        }


        [HttpGet]
        [Route("ConfirmEmail", Name = "ConfirmEmailRoute")]
        public async Task<IHttpActionResult> ConfirmEmail(string userId = "", string code = "")
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }

            IdentityResult result = await BcUserManager.GetUserManager().ConfirmEmailAsync(userId, code);

            if (result.Succeeded)
            {
                return Redirect("http://localhost:33452/");//Ok();
            }
            else
            {
                return GetErrorResult(result);
            }
        }





        [Authorize]
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await BcUserManager.GetUserManager().ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        [Authorize(Roles = "admin")]
        [Route("user/{id:guid}")]
        public async Task<IHttpActionResult> DeleteUser(string id)
        {

            //Only SuperAdmin or Admin can delete users (Later when implement roles)

            var appUser = await BcUserManager.GetUserManager().FindByIdAsync(id);

            if (appUser != null)
            {
                IdentityResult result = await BcUserManager.GetUserManager().DeleteAsync(appUser);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok();

            }

            return NotFound();

        }

        //[Route("user/{id:guid}", Name = "GetUserById")]
        //public async Task<IHttpActionResult> GetUser(string Id)
        //{
        //    var user = await this.AppUserManager.FindByIdAsync(Id);

        //    if (user != null)
        //    {
        //        return Ok(this.TheModelFactory.Create(user));
        //    }

        //    return NotFound();

        //}

        //[Route("user/{username}")]
        //public async Task<IHttpActionResult> GetUserByName(string username)
        //{
        //    var user = await this.AppUserManager.FindByNameAsync(username);

        //    if (user != null)
        //    {
        //        return Ok(this.TheModelFactory.Create(user));
        //    }

        //    return NotFound();

        //}

        //[HttpPost]
        //[Route("create")]
        //public async Task<IHttpActionResult> CreateUser([FromBody]CreateUserBindingModel createUserModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = new User()
        //    {
        //        UserName = createUserModel.Username,
        //        Email = createUserModel.Email,
        //        FirstName = createUserModel.FirstName,
        //        LastName = createUserModel.LastName,
        //        JoinDate = DateTime.Now.Date,
        //    };

        //    IdentityResult addUserResult = await this.AppUserManager.CreateAsync(user, createUserModel.Password);

        //    if (!addUserResult.Succeeded)
        //    {
        //        return GetErrorResult(addUserResult);
        //    }

        //    Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

        //    return Created(locationHeader, TheModelFactory.Create(user));
        //}

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}

