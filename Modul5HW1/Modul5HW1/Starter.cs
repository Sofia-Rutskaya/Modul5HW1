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

            var usersList = Task.Run(async () => await _userService.UsersList());
            var singleUser = Task.Run(async () => await _userService.SingleUser());
            var singleUserNotFound = Task.Run(async () => await _userService.SingleUserNotFound());
            var create = Task.Run(async () => await _userService.Create());
            var updatePut = Task.Run(async () => await _userService.UpdatePut());
            var updatePatch = Task.Run(async () => await _userService.UpdatePatch());
            var delete = Task.Run(async () => await _userService.Delete());
            var delayed = Task.Run(async () => await _userService.Delayed());

            _resourceService = new ResourceService(_configService, _httpService);
            var resourceList = Task.Run(async () => await _resourceService.ResourceList());
            var singleResource = Task.Run(async () => await _resourceService.SingleResource());
            var singleResourceNotFound = Task.Run(async () => await _resourceService.SingleResourceNotFound());

            _authService = new AuthService(_configService, _httpService);
            var registerSuccessful = Task.Run(async () => await _authService.RegisterSuccessful());
            var registerUnsuccessful = Task.Run(async () => await _authService.RegisterUnsuccessful());
            var loginSuccessful = Task.Run(async () => await _authService.LoginSuccessful());
            var loginUnsuccessful = Task.Run(async () => await _authService.LoginUnsuccessful());

            await Task.WhenAll(
                usersList,
                singleUser,
                singleUserNotFound,
                create,
                updatePut,
                updatePatch,
                delete,
                delayed,
                resourceList,
                singleResource,
                singleResourceNotFound,
                registerSuccessful,
                registerUnsuccessful,
                loginSuccessful,
                loginUnsuccessful);
        }
    }
}
