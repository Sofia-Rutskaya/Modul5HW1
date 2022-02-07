using Modul5HW1.Services;
using Modul5HW1.Services.Addictional;

namespace Modul5HW1
{
    public class Starter
    {
        private readonly IHttpService _httpService;
        private readonly ConfigService _configService;
        private IUserService? _userService;
        private IResourceService? _resourceService;
        private IAuthService? _authService;

        public Starter(IHttpService httpService)
        {
            _httpService = httpService;
            _configService = new ConfigService();
        }

        public async void Run()
        {
            _userService = new UserService(_configService, _httpService);

            await _userService.UsersList();
            await _userService.SingleUser();
            await _userService.SingleUserNotFound();
            await _userService.Create();
            await _userService.UpdatePut();
            await _userService.UpdatePatch();
            await _userService.Delete();
            await _userService.Delayed();

            _resourceService = new ResourceService(_configService, _httpService);
            await _resourceService.ResourceList();
            await _resourceService.SingleResource();
            await _resourceService.SingleResourceNotFound();

            _authService = new AuthService(_configService, _httpService);
            await _authService.RegisterSuccessful();
            await _authService.RegisterUnsuccessful();
            await _authService.LoginSuccessful();
            await _authService.LoginUnsuccessful();
        }
    }
}
