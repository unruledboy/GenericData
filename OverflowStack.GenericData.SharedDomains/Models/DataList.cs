using System.Collections.Generic;

namespace OverflowStack.GenericData.SharedDomains.Models
{
    public class DataList
    {
        public List<string> Columns { get; set; }
        public List<DataRecord> Records { get; set; }
    }
}
