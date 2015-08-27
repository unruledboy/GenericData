using OverflowStack.GenericData.ServerDomains.Models;
using OverflowStack.GenericData.SharedDomains.Models;

namespace OverflowStack.GenericData.ServerDomains.DataAccess
{
    public abstract class BaseDataAccess
    {
        public abstract string ConnectionType { get; }

        public abstract DataList Process(Request request, Connection connection, Schema schema);
    }
}
