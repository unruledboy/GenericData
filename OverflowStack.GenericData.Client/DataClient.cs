using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using OverflowStack.GenericData.ClientDomains.Models;
using OverflowStack.GenericData.SharedDomains.Models;

namespace OverflowStack.GenericData.Client
{
    public class DataClient
    {
        private readonly Uri _uri;
        private ClientConfig _config;

        public DataClient(Uri uri, string configFile)
        {
            _uri = uri;
            _config = new ConfigReader(configFile).Read();
        }

        public async Task<Response> Send(Request request)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _uri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync("api/service/accept", request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsAsync<Response>();
                    return content;
                }
                return null;
            }
        }

        public Payload BuildPayload(string schemaId, List<object> objects)
        {
            var schema = _config.Schemas.First(s => s.Id == schemaId);
            var columns = schema.Parameters.Select(p => p.Name).ToList();
            var payload = new Payload
            {
                Schema = schemaId,
                Data = new DataList
                {
                    Columns = columns,
                    Records = new List<DataRecord>
                        {
                           new DataRecord 
                           {
                               Values = objects
                           } 
                        }
                }
            };
            return payload;
        }

        public Request BuildRequest(Payload payload, string tag, string token, string userId)
        {
            return new Request {CreatedDate = DateTime.Now, Id = Guid.NewGuid(), Machine = Environment.MachineName, Payload = payload, Tag = tag, Token = token, UserId = userId};
        }
    }
}
