using OverflowStack.GenericData.SharedDomains;
using OverflowStack.GenericData.SharedDomains.Models;

namespace OverflowStack.GenericData.Services.Logic
{
    public class Pulser
    {
        public static PulseResponse Pulse()
        {
            var response = Utils.CreateResponse<PulseResponse>(true);
            //todo:
            response.Status = ServerStatus.Normal;
            return response;
        }
    }
}