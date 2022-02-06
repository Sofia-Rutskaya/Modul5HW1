using Newtonsoft.Json;
using Modul5HW1.DTO;
using Modul5HW1.DTO.Queries;

public class Program
{
    public static void Main(string[] args)
    {
    // {
    //    var send = new SendQuery<SingleUser>();
    //    send.SendPost(@"https://reqres.in/api/users/2").GetAwaiter().GetResult(); // Вынести в конфиг
    //    send.SendPost(@"https://reqres.in/api/users/23").GetAwaiter().GetResult();
        var get = new SendQuery<Root>();
        get.SendPost(@"https://reqres.in/api/users?page=2").GetAwaiter().GetResult();
    }
}
