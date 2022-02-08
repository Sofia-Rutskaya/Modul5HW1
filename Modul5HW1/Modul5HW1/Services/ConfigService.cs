using Modul5HW1.Configurations;
using Modul5HW1.Services.Addictional;
using Newtonsoft.Json;

namespace Modul5HW1.Services
{
    public class ConfigService : IConfigService
    {
        public ConfigURL? ConfigDeserialize()
        {
            var configFile = File.ReadAllText("config.json");
            var config = JsonConvert.DeserializeObject<ConfigURL>(configFile);
            return config;
        }

        public void ConfigSerialize(object? config, string fileName)
        {
            var json = JsonConvert.SerializeObject(config);
            File.WriteAllText(@$"C:\Users\admin\Source\Repos\Sofia-Rutskaya\Modul5HW1\Modul5HW1\Modul5HW1\Models\Response\{fileName}", json);
        }
    }
}
