using System.Web.Hosting;
using System.Web.Http;
using OverflowStack.GenericData.Services.Logic.Core;
using OverflowStack.GenericData.SharedDomains.Models;

namespace OverflowStack.GenericData.Services.Controllers
{
    public class ServiceController : ApiController
    {
        public Response Accept(Request id)
        {
            Response response = null;
            var config = new ConfigReader(HostingEnvironment.MapPath("~/App_Data/ServerConfig.xml")).Read();
            var handlers = HandlerFactory.Find(id);
            foreach (var handler in handlers)
            {
                if (handler.Process(id, config, out response))
                    break;
            }
            return response;
        }
    }
}
