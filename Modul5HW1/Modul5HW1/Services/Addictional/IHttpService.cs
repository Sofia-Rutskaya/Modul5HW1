namespace Modul5HW1.Services.Addictional
{
    public interface IHttpService
    {
        Task SendPost<T>(string url);
    }
}
