namespace Modul5HW1.Services.Addictional
{
    public interface IUserService
    {
        Task UsersList();
        Task SingleUser();
        Task SingleUserNotFound();
        Task Create();
        Task UpdatePut();
    }
}
