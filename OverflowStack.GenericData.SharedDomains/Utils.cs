using System;
using System.IO;
using System.Xml.Serialization;
using OverflowStack.GenericData.SharedDomains.Models;

namespace OverflowStack.GenericData.SharedDomains
{
    public static class Utils
    {
        public static T DeserializeFile<T>(string file)
        {
            var result = default(T);
            var deserializer = new XmlSerializer(typeof(T));
            using (var stream = File.OpenRead(file))
            {
                using (var reader = new StreamReader(stream))
                {
                    try
                    {
                        result = (T)deserializer.Deserialize(reader);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return result;
        }

        public static T CreateResponse<T>(bool successful = true, string tag = "") where T : BaseResponse, new()
        {
            return new T { CreatedDate = DateTime.Now.ToUniversalTime(), Id = Guid.NewGuid(), Successful = successful, Tag = tag };
        }
    }
}
