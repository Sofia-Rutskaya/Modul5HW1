using Modul5HW1.Services;
using Modul5HW1.Services.Addictional;

namespace Modul5HW1
{
    public class Starter
    {
        private readonly IHttpService _httpService;
        private readonly ConfigService _configService;

        public Starter(IHttpService httpService)
        {
            _httpService = httpService;
            _configService = new ConfigService();
        }

        public void Run()
        {
            var request = new UserService(_configService, _httpService);
            request.UsersList().GetAwaiter().GetResult();
            request.SingleUser().GetAwaiter().GetResult();
            request.SingleUserNotFound().GetAwaiter().GetResult();
        }
    }
}
