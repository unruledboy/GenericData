using System.Web.Http;
using OverflowStack.GenericData.Services.Logic;
using OverflowStack.GenericData.SharedDomains.Models;

namespace OverflowStack.GenericData.Services.Controllers
{
    public class ServiceController : ApiController
    {
        [HttpGet]
        public PulseResponse Pulse()
        {
            return Pulser.Pulse();
        }

        public BaseResponse Accept(Request id)
        {
            return DataProcessor.Process(id);
        }
    }
}
