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

        public async Task<T?> SendPost<T>(string url, Mode mode, HttpContent? httpContent = null)
        {
            switch (mode)
            {
                case Mode.GET:
                    var result = await _httpClient.GetAsync(url);
                    Console.WriteLine(result.StatusCode);
                    if (result.IsSuccessStatusCode)
                    {
                        var contentGet = await result.Content.ReadAsStringAsync();
                        var userGet = JsonConvert.DeserializeObject<T>(contentGet);
                        return userGet;
                    }

                    break;
                case Mode.POST:

                    var responsePost = await _httpClient.PostAsync(url, httpContent);
                    Console.WriteLine(responsePost.StatusCode);
                    var contentPost = await responsePost.Content.ReadAsStringAsync();
                    var userPost = JsonConvert.DeserializeObject<T>(contentPost);
                    return userPost;

                case Mode.PUT:

                    var responsePut = await _httpClient.PutAsync(url, httpContent);
                    Console.WriteLine(responsePut.StatusCode);
                    var contentPut = await responsePut.Content.ReadAsStringAsync();
                    var userPut = JsonConvert.DeserializeObject<T>(contentPut);
                    return userPut;

                case Mode.PATCH:

                    var responsePatch = await _httpClient.PatchAsync(url, httpContent);
                    Console.WriteLine(responsePatch.StatusCode);
                    var contentPatch = await responsePatch.Content.ReadAsStringAsync();
                    var userPatch = JsonConvert.DeserializeObject<T>(contentPatch);
                    return userPatch;
                case Mode.DELETE:

                    var responseDelete = await _httpClient.DeleteAsync(url);
                    Console.WriteLine(responseDelete.StatusCode);
                    var contentDelete = await responseDelete.Content.ReadAsStringAsync();
                    var userDelete = JsonConvert.DeserializeObject<T>(contentDelete);
                    return userDelete;
            }

            return default(T);
        }
    }
}
