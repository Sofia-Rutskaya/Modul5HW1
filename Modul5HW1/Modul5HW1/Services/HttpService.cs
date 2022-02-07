using Newtonsoft.Json;
using Modul5HW1.Models.DTO;
using Modul5HW1.Services.Addictional;

namespace Modul5HW1.Services
{
    public class HttpService : IHttpService
    {
        private HttpClient _httpClient;
        public HttpService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T?> SendPost<T>(string url)
        {
            var result = await _httpClient.GetAsync(url);
            Console.WriteLine(result.StatusCode);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<T>(content);
                return user;
            }

            return default(T);
        }
    }
}
