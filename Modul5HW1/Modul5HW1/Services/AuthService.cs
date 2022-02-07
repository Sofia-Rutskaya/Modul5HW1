using Modul5HW1.Models.DTO;
using Modul5HW1.Models.Request;
using Modul5HW1.Services.Addictional;
using Newtonsoft.Json;

namespace Modul5HW1.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpService _httpService;
        private readonly ConfigService _config;
        public AuthService(ConfigService config, IHttpService httpService)
        {
            _httpService = httpService;
            _config = config;
        }

        public async Task RegisterSuccessful()
        {
            Console.Write($"{nameof(RegisterSuccessful)}: ");
            var user = new
            {
                email = "eve.holt@reqres.in",
                password = "pistol"
            };
            var client = new StringContent(JsonConvert.SerializeObject(user), System.Text.UTF8Encoding.UTF8, "application/json");
            var list = await _httpService.SendPost<RegisterSuccessful>(@$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.RegisterUrl}", Mode.POST, client);
            _config.ConfigSerialize(list, "registerSuccessful.json");
        }
    }
}
