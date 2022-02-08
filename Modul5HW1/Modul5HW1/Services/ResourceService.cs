using Modul5HW1.Models.DTO;
using Modul5HW1.Models.Request;
using Modul5HW1.Services.Addictional;

namespace Modul5HW1.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IHttpService _httpService;
        private readonly IConfigService _config;
        public ResourceService(IConfigService config, IHttpService httpService)
        {
            _httpService = httpService;
            _config = config;
        }

        public async Task ResourceList()
        {
            var url = @$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.ResourceUrl}";
            await _httpService.SendPost<ResourceList>(url, HttpMethod.Get, nameof(ResourceList));
        }

        public async Task SingleResource()
        {
            var url = @$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.ResourceUrl}/2";
            await _httpService.SendPost<ResourceSupport>(url, HttpMethod.Get, nameof(SingleResource));
        }

        public async Task SingleResourceNotFound()
        {
            var url = @$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.ResourceUrl}/23";
            await _httpService.SendPost<ResourceSupport>(url, HttpMethod.Get, nameof(SingleResourceNotFound));
        }
    }
}
