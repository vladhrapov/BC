using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace BC.Web.Rest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Register Web Api Routes
            //GlobalConfiguration.Configure(WebApiConfig.Register);

            // Register MVC Routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Startup.Configuration();
        }
    }
}
