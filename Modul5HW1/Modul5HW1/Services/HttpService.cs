using Newtonsoft.Json;
using Modul5HW1.Models.DTO;
using Modul5HW1.Services.Addictional;

namespace Modul5HW1.Services
{
    public class HttpService : IHttpService
    {
        private readonly IConfigService _config;
        private HttpClient _httpClient;
        public HttpService(IConfigService configService)
        {
            _httpClient = new HttpClient();
            _config = configService;
        }

        public async Task SendPost<T>(string url, HttpMethod mode, string fileName, object? httpContent = null)
        {
            var request = new HttpRequestMessage(mode, url);

            if (httpContent != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(httpContent), System.Text.UTF8Encoding.UTF8, "application/json");
            }

            var result = await _httpClient.SendAsync(request);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<T>(content);

                _config.ConfigSerialize(user, $"{fileName}.json");
            }
        }
    }
}
