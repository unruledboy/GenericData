using System.Collections.Generic;
using System.Linq;
using OverflowStack.GenericData.ServerDomains.Handlers;
using OverflowStack.GenericData.SharedDomains.Models;

namespace OverflowStack.GenericData.Services.Logic.Core
{
    public class HandlerFactory
    {
        private static readonly List<BaseHandler> _handlers = new List<BaseHandler>();

        public static void Add(BaseHandler handler)
        {
            _handlers.Add(handler);
        }

        public static IEnumerable<BaseHandler> Find(Request request)
        {
            if (string.IsNullOrEmpty(request.Handler))
                return _handlers.Take(1);
            var result = _handlers.Where(h => h.Handler == request.Handler);
            return result;
        }
    }
}