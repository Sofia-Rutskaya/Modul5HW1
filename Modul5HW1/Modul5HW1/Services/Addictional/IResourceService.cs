namespace Modul5HW1.Services.Addictional
{
    public interface IResourceService
    {
        Task ResourceList();
        Task SingleResource();
        Task SingleResourceNotFound();
    }
}
