namespace Modul5HW1.Services.Addictional
{
    public interface IAuthService
    {
        Task RegisterSuccessful();
        Task RegisterUnsuccessful();
        Task LoginSuccessful();
        Task LoginUnsuccessful();
    }
}
