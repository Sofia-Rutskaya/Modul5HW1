using Modul5HW1.Models.DTO;
using Modul5HW1.Models.Request;
using Modul5HW1.Services.Addictional;

namespace Modul5HW1.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IHttpService _httpService;
        private readonly ConfigService _config;
        public ResourceService(ConfigService config, IHttpService httpService)
        {
            _httpService = httpService;
            _config = config;
        }

        public async Task ResourceList()
        {
            Console.Write($"{nameof(ResourceList)}: ");
            var list = await _httpService.SendPost<ResourceList>(@$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.ResourceUrl}");
            _config.ConfigSerialize(list, "resourceList.json");
        }

        public async Task SingleResource()
        {
            Console.Write($"{nameof(SingleResource)}: ");
            var list = await _httpService.SendPost<ResourceSupport>(@$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.ResourceUrl}/2");
            _config.ConfigSerialize(list, "singleResource.json");
        }

        public async Task SingleResourceNotFound()
        {
            Console.Write($"{nameof(SingleResourceNotFound)}: ");
            var list = await _httpService.SendPost<ResourceSupport>(@$"{_config.ConfigDeserialize()?.URL}{_config.ConfigDeserialize()?.ResourceUrl}/23");
            _config.ConfigSerialize(list, "singleResourceNotFound.json");
        }
    }
}
