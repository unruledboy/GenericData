namespace OverflowStack.GenericData.SharedDomains.Models
{
    public class ErrorResponse : BaseResponse
    {
        public string Message { get; set; }
        public string Detail { get; set; }
    }
}
