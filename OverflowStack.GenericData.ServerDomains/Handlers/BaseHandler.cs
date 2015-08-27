using OverflowStack.GenericData.ServerDomains.Models;
using OverflowStack.GenericData.SharedDomains.Models;

namespace OverflowStack.GenericData.ServerDomains.Handlers
{
    public abstract class BaseHandler
    {
        public abstract string Handler { get; }

        public abstract bool Process(Request request, ServerConfig config, out Response response);
    }
}
