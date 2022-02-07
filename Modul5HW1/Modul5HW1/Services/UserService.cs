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
            Console.Write($"{nameof(UsersList)}: ");
            var list = await _httpService.SendPost<UserList>(@$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}/?page=2", Mode.GET);
            _config.ConfigSerialize(list, "usersList.json");
        }

        public async Task SingleUser()
        {
            Console.Write($"{nameof(SingleUser)}: ");
            var list = await _httpService.SendPost<UserSupport>(@$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}/2", Mode.GET);
            _config.ConfigSerialize(list, "singleUser.json");
        }

        public async Task SingleUserNotFound()
        {
            Console.Write($"{nameof(SingleUserNotFound)}: ");
            var list = await _httpService.SendPost<UserSupport>(@$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}/23", Mode.GET);
            _config.ConfigSerialize(list, "singleUserNotFound.json");
        }

        public async Task Create()
        {
                Console.Write($"{nameof(Create)}: ");
                var user = new
                {
                    name = "morpheus",
                    job = "leader"
                };
                var client = new StringContent(JsonConvert.SerializeObject(user), System.Text.UTF8Encoding.UTF8, "application/json");
                var list = await _httpService.SendPost<Create>(@$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}", Mode.POST, client);
                _config.ConfigSerialize(list, "create.json");
        }

        public async Task UpdatePut()
        {
                Console.Write($"{nameof(UpdatePut)}: ");
                var user = new
                {
                    name = "morpheus",
                    job = "zion resident"
                };
                var client = new StringContent(JsonConvert.SerializeObject(user), System.Text.UTF8Encoding.UTF8, "application/json");
                var list = await _httpService.SendPost<Update>(@$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}/2", Mode.PUT, client);
                _config.ConfigSerialize(list, "updatePut.json");
        }

        public async Task UpdatePatch()
        {
                Console.Write($"{nameof(UpdatePatch)}: ");
                var user = new
                {
                    name = "morpheus",
                    job = "zion resident"
                };
                var client = new StringContent(JsonConvert.SerializeObject(user), System.Text.UTF8Encoding.UTF8, "application/json");
                var list = await _httpService.SendPost<Update>(@$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}/2", Mode.PATCH, client);
                _config.ConfigSerialize(list, "updatePatch.json");
        }

        public async Task Delete()
        {
                Console.Write($"{nameof(Delete)}: ");
                var list = await _httpService.SendPost<Update>(@$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}/2", Mode.DELETE);
                _config.ConfigSerialize(list, "delete.json");
        }
    }
}
