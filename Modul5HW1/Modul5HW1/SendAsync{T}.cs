using Newtonsoft.Json;
using Modul5HW1.Models.DTO;

public class SendAsync<T>
{
    private HttpClient? _httpClient;
    public async Task SendPost(string url)
    {
        using (_httpClient = new HttpClient())
        {
            var result = await _httpClient.GetAsync(url);
            Console.WriteLine(result.StatusCode);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<T>(content);
            }
        }
    }
}