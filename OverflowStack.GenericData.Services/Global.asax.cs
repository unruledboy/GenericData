using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace OverflowStack.GenericData.Services
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ServiceBootstrap.Init();
        }
    }
}
