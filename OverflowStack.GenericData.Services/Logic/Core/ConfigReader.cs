using OverflowStack.GenericData.ServerDomains.Models;
using OverflowStack.GenericData.SharedDomains;

namespace OverflowStack.GenericData.Services.Logic.Core
{
    public class ConfigReader
    {
        private readonly string _file;

        public ConfigReader(string file)
        {
            _file = file;
        }

        public ServerConfig Read()
        {
            return Utils.DeserializeFile<ServerConfig>(_file);
        }
    }
}