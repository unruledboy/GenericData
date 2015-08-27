using System;
using System.Linq;
using OverflowStack.GenericData.ServerDomains;
using OverflowStack.GenericData.ServerDomains.Handlers;
using OverflowStack.GenericData.ServerDomains.Models;
using OverflowStack.GenericData.Services.Logic.Core;
using OverflowStack.GenericData.SharedDomains.Models;

namespace OverflowStack.GenericData.Services.Logic.Handlers
{
    public class GenericHandler : BaseHandler
    {
        public override string Handler
        {
            get { return Constants.HandlerGeneric; }
        }

        public override bool Process(Request request, ServerConfig config, out Response response)
        {
            var schema = config.Schemas.FirstOrDefault(s => s.Id == request.Payload.Schema);
            if (schema != null)
            {
                var connection = config.Connections.FirstOrDefault(c => c.Id == schema.Connection);
                if (connection != null)
                {
                    var dataAccess = DataFactory.Find(connection);
                    if (dataAccess != null)
                    {
                        var dataList = dataAccess.Process(request, connection, schema);
                        response = new Response { CreatedDate = DateTime.Now, Id = request.Id, Payload = new Payload { Schema = request.Payload.Schema, Data = dataList }, Tag = request.Tag };
                        return true;
                    }
                }
            }
            response = null;
            return true;
        }
    }
}