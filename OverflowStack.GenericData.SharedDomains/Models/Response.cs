using System;

namespace OverflowStack.GenericData.SharedDomains.Models
{
    public class Response
    {
        public Guid Id { get; set; }
        public string Tag { get; set; }
        public DateTime CreatedDate { get; set; }
        public Payload Payload { get; set; }
    }
}
