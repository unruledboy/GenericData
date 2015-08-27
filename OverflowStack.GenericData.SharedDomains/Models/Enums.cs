namespace OverflowStack.GenericData.SharedDomains.Models
{
    public enum OperationType
    {
        Create = 1,
        Retrieve = 2,
        Update = 3,
        Delete = 4
    }

    public enum ServerStatus
    {
        Disabled = 0,
        Normal = 1,
        Busy = 2
    }
}