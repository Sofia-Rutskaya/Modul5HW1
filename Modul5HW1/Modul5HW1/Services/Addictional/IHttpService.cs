namespace Modul5HW1.Services.Addictional
{
    public interface IHttpService
    {
        Task<T?> SendPost<T>(string url);
    }
}
