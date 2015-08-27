using OverflowStack.GenericData.Services.Logic.Core;
using OverflowStack.GenericData.Services.Logic.DataAccess;
using OverflowStack.GenericData.Services.Logic.Handlers;

namespace OverflowStack.GenericData.Services
{
    public class ServiceBootstrap
    {
        public static void Init()
        {
            HandlerFactory.Add(new GenericHandler());
            DataFactory.Add(new SqlDataAccess());
        }
    }
}