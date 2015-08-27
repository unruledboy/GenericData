using System;

namespace OverflowStack.GenericData.SharedDomains.Models
{
    public class BaseResponse
    {
        public Guid Id { get; set; }
        public string Tag { get; set; }
        public bool Successful { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
