using Microsoft.Extensions.DependencyInjection;
using Modul5HW1.Services;
using Modul5HW1.Services.Addictional;

namespace Modul5HW1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new HttpClient();

            var serviceProvider = new ServiceCollection()
               .AddSingleton<IUserService, UserService>()
               .AddSingleton<IAuthService, AuthService>()
               .AddSingleton<IHttpService, HttpService>()
               .AddTransient<Starter>()
               .BuildServiceProvider();

            var start = serviceProvider.GetService<Starter>();
            start?.Run();

            Console.Read();
        }
    }
}