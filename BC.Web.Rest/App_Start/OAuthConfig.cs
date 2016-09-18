using BC.Infrastructure.Business;
using BC.Infrastructure.Business.Authentication;
using BC.Infrastructure.Data;
//using Microsoft.AspNet.Identity.Owin;
using Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using BC.Web.Rest.Providers;
using System.Web.Http;
using Microsoft.Owin.Cors;
using System.Web.Routing;
using System.Configuration;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;

[assembly: OwinStartup(typeof(BC.Web.Rest.Startup))]

namespace BC.Web.Rest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            //app.CreatePerOwinContext(BaseService.GetUow().GetContext);
            //app.CreatePerOwinContext<BcUserManager>(BcUserManager.GetUserManager);

            var httpConfiguration = new HttpConfiguration();
            var routeCollection = new RouteCollection();


            // Plugin the OAuth bearer JSON Web Token tokens generation and Consumption will be here
            OAuthAuthorizationServerOptions authOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new BcOAuthProvider(),
                AccessTokenFormat = new BcJwtFormat(ConfigurationManager.AppSettings["Issuer"])
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(authOptions);

            

            ConfigureOAuthTokenConsumption(app);


            app.UseWebApi(WebApiConfig.RegisterWebApi(httpConfiguration));

            //RouteConfig.RegisterMVCRoutes(routeCollection).MapOwinRoute();

            app.UseCors(CorsOptions.AllowAll);

        }

        private void ConfigureOAuthTokenConsumption(IAppBuilder app)
        {

            var issuer = ConfigurationManager.AppSettings["Issuer"];
            string audienceId = ConfigurationManager.AppSettings["AudienceId"];
            //byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["AudienceSecret"]);
            byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["AudienceSecret"]);
            //var audienceSecret = Convert.FromBase64String(ConfigurationManager.AppSettings["AudienceSecret"].Substring(0, 32));

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions()
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                        
                    }
                });


        }

    }
}