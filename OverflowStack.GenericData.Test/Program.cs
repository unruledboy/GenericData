using System;
using System.Collections.Generic;
using System.Linq;
using OverflowStack.GenericData.Client;
using OverflowStack.GenericData.SharedDomains.Models;

namespace OverflowStack.GenericData.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new DataClient(new Uri("http://localhost:52524/"), string.Format(@"{0}\ClientConfig.xml", AppDomain.CurrentDomain.BaseDirectory));
            var response = TestAdd(client);
            if (response != null)
            {
                OutputResponse(response);

                //expecting Id
                var records = response.Payload.Data.Records;
                if (records.Any())
                {
                    response = TestUpdate(client, records.First());
                    OutputResponse(response);
                }
                Console.WriteLine("done");
            }
            else
                Console.WriteLine("oops");
            Console.Read();
        }

        private static Response TestUpdate(DataClient client, DataRecord record)
        {
            var payload = client.BuildPayload("TestUser", new List<object> { record.Values[0], "John Doe", "America", "1989-02-28", false, 23, 135.79, DateTime.Now });            
            var request = client.BuildRequest(payload, "update", "1234", "user1");
            var response = client.Send(request);
            return response.Result;
        }

        private static void OutputResponse(Response response)
        {
            var data = response.Payload.Data;
            foreach (var column in data.Columns)
            {
                Console.Write("{0}\t", column);
            }
            Console.WriteLine();
            foreach (var record in data.Records)
            {
                for (var i = 0; i < data.Columns.Count; i++)
                {
                    Console.Write("{0}\t", record.Values[i]);
                }
                Console.WriteLine();
            }
        }

        private static Response TestAdd(DataClient client)
        {
            var payload = client.BuildPayload("TestUser", new List<object> {Guid.Empty, "Jane Citizen", "Australia", "1985-01-23", true, 12, 345.678, DateTime.Now});
            var request = client.BuildRequest(payload, "add", "1234", "user1");
            var response = client.Send(request);
            return response.Result;
        }
    }
}
