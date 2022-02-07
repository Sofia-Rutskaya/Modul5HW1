using Modul5HW1.Configurations;
using Newtonsoft.Json;

namespace Modul5HW1.Services
{
    public class ConfigService
    {
        public ConfigURL? ConfigDeserialize()
        {
            var configFile = File.ReadAllText("config.json");
            var config = JsonConvert.DeserializeObject<ConfigURL>(configFile);
            return config;
        }
    }
}
