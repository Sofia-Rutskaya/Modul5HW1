using Modul5HW1.Models.DTO;
using Modul5HW1.Models.Request;
using Modul5HW1.Services.Addictional;
using Newtonsoft.Json;

namespace Modul5HW1.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpService _httpService;
        private readonly ConfigService _config;
        public UserService(ConfigService config, IHttpService httpService)
        {
            _httpService = httpService;
            _config = config;
        }

        public async Task UsersList()
        {
            var url = @$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}/?page=2";
            await _httpService.SendPost<UserList>(url, HttpMethod.Get, nameof(UsersList));
        }

        public async Task SingleUser()
        {
            var url = @$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}/2";
            await _httpService.SendPost<UserSupport>(url, HttpMethod.Get, nameof(SingleUser));
        }

        public async Task SingleUserNotFound()
        {
            var url = @$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}/23";
            await _httpService.SendPost<UserSupport>(url, HttpMethod.Get, nameof(SingleUserNotFound));
        }

        public async Task Create()
        {
            var user = new
            {
                name = "morpheus",
                job = "leader"
            };

            var url = @$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}";
            await _httpService.SendPost<Create>(url, HttpMethod.Post, nameof(Create), user);
        }

        public async Task UpdatePut()
        {
            var user = new
            {
                name = "morpheus",
                job = "zion resident"
            };

            var url = @$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}/2";
            await _httpService.SendPost<Update>(url, HttpMethod.Put, nameof(UpdatePut), user);
        }

        public async Task UpdatePatch()
        {
            var user = new
            {
                name = "morpheus",
                job = "zion resident"
            };
            var url = @$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}/2";
            await _httpService.SendPost<Update>(url, HttpMethod.Patch, nameof(UpdatePatch), user);
        }

        public async Task Delete()
        {
            var url = @$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}/2";
            await _httpService.SendPost<Update>(url, HttpMethod.Delete, nameof(Delete));
        }

        public async Task Delayed()
        {
            var url = @$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}/?delay=3";
            await _httpService.SendPost<UserList>(url, HttpMethod.Get, nameof(Delayed));
        }
    }
}
