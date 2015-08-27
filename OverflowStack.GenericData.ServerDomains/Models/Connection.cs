using System.Xml.Serialization;

namespace OverflowStack.GenericData.ServerDomains.Models
{
    public class Connection
    {
        [XmlAttribute]
        public string Id { get; set; }

        [XmlAttribute]
        public string ConnectionType { get; set; }

        [XmlText]
        public string ConnectionString { get; set; }
    }
}