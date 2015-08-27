using System;

namespace OverflowStack.GenericData.SharedDomains.Models
{
    public class Request
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Machine { get; set; }
        public string Tag { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Handler { get; set; }
        public Payload Payload { get; set; }
    }
}
