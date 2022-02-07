using Modul5HW1.Models.DTO;
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
            await _httpService.SendPost<Root>(@$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.UserUrl}?page=2");
        }
    }
}
