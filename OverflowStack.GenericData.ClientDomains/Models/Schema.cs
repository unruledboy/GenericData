using System.Collections.Generic;
using System.Xml.Serialization;
using OverflowStack.GenericData.SharedDomains.Models;

namespace OverflowStack.GenericData.ClientDomains.Models
{
    public class Schema
    {
        [XmlAttribute]
        public string Id { get; set; }

        [XmlAttribute]
        public OperationType OperationType { get; set; }

        [XmlArrayItem("Parameter")]
        public List<Parameter> Parameters { get; set; }
    }
}