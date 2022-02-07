using Modul5HW1.Models.DTO;
using Modul5HW1.Models.Request;
using Modul5HW1.Services.Addictional;

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
    }
}
