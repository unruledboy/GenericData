using OverflowStack.GenericData.ClientDomains.Models;
using OverflowStack.GenericData.SharedDomains;

namespace OverflowStack.GenericData.Client
{
    public class ConfigReader
    {
        private readonly string _file;

        public ConfigReader(string file)
        {
            _file = file;
        }

        public ClientConfig Read()
        {
            return Utils.DeserializeFile<ClientConfig>(_file);
        }
    }
}