using Modul5HW1.Models.DTO;
using Modul5HW1.Models.Request;
using Modul5HW1.Services.Addictional;
using Newtonsoft.Json;

namespace Modul5HW1.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpService _httpService;
        private readonly IConfigService _config;
        public AuthService(IConfigService config, IHttpService httpService)
        {
            _httpService = httpService;
            _config = config;
        }

        public async Task RegisterSuccessful()
        {
            var user = new
            {
                email = "eve.holt@reqres.in",
                password = "pistol"
            };
            var url = @$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.RegisterUrl}";
            await _httpService.SendPost<RegisterSuccessful>(url, HttpMethod.Post, nameof(RegisterSuccessful), user);
        }

        public async Task RegisterUnsuccessful()
        {
            var user = new
            {
                email = "sydney@fife"
            };
            var url = @$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.RegisterUrl}";
            await _httpService.SendPost<SomeError>(url, HttpMethod.Post, nameof(RegisterUnsuccessful), user);
        }

        public async Task LoginSuccessful()
        {
            var user = new
            {
                email = "eve.holt@reqres.in",
                password = "cityslicka"
            };
            var url = @$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.LoginUrl}";
            await _httpService.SendPost<SomeToken>(url, HttpMethod.Post, nameof(LoginSuccessful), user);
        }

        public async Task LoginUnsuccessful()
        {
            var user = new
            {
                email = "peter@klaven"
            };
            var url = @$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.LoginUrl}";
            await _httpService.SendPost<SomeError>(url, HttpMethod.Post, nameof(LoginUnsuccessful), user);
        }
    }
}
