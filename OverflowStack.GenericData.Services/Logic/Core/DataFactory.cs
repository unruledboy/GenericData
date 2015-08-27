using System.Collections.Generic;
using System.Linq;
using OverflowStack.GenericData.ServerDomains.DataAccess;
using OverflowStack.GenericData.ServerDomains.Models;

namespace OverflowStack.GenericData.Services.Logic.Core
{
    public class DataFactory
    {
        private static readonly List<BaseDataAccess> _dataAccess = new List<BaseDataAccess>();

        public static void Add(BaseDataAccess handler)
        {
            _dataAccess.Add(handler);
        }

        public static BaseDataAccess Find(Connection connection)
        {
            var result = _dataAccess.FirstOrDefault(h => h.ConnectionType == connection.ConnectionType);
            return result;
        }
    }
}