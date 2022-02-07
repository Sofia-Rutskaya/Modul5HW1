using Modul5HW1.Models.DTO;
using Modul5HW1.Models.Request;
using Modul5HW1.Services.Addictional;

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
            var list = await _httpService.SendPost<UserList>(@$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}?page=2");
            _config.ConfigSerialize(list, "usersList.json");
        }

        public async Task SingleUser()
        {
            Console.Write($"{nameof(SingleUser)}: ");
            var list = await _httpService.SendPost<UserSupport>(@$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}2");
            _config.ConfigSerialize(list, "singleUser.json");
        }

        public async Task SingleUserNotFound()
        {
            Console.Write($"{nameof(SingleUserNotFound)}: ");
            var list = await _httpService.SendPost<UserSupport>(@$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}23");
            _config.ConfigSerialize(list, "singleUserNotFound.json");
        }
    }
}
