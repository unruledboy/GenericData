using System.Collections.Generic;
using System.Xml.Serialization;
using OverflowStack.GenericData.SharedDomains.Models;

namespace OverflowStack.GenericData.ServerDomains.Models
{
    public class Schema
    {
        [XmlAttribute]
        public string Id { get; set; }

        [XmlAttribute]
        public string Connection { get; set; }

        [XmlAttribute]
        public string CommandText { get; set; }

        [XmlAttribute]
        public string CommandType { get; set; }

        [XmlAttribute]
        public OperationType OperationType { get; set; }

        [XmlArrayItem("Parameter")]
        public List<Parameter> Parameters { get; set; }
    }
}