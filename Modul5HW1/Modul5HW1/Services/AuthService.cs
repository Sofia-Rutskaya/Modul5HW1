namespace Modul5HW1.Services
{
    public class AuthService
    {
        private HttpService _httpService;
        public AuthService(HttpService httpService)
        {
            _httpService = httpService;
        }
    }
}
