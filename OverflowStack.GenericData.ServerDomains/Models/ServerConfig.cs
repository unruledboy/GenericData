using System.Collections.Generic;

namespace OverflowStack.GenericData.ServerDomains.Models
{
    public class ServerConfig
    {
        public List<Connection> Connections { get; set; }
        public List<Schema> Schemas { get; set; }
    }
}