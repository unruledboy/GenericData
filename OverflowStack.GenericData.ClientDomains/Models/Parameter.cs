using System.Xml.Serialization;

namespace OverflowStack.GenericData.ClientDomains.Models
{
    public class Parameter
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public int Size { get; set; }

        [XmlAttribute]
        public byte Precision { get; set; }

        [XmlAttribute]
        public string DataType { get; set; }
    }
}