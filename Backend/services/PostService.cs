using Backend.DTOs;
using System.Text.Json;

namespace Backend.services
{
    public class PostService : IPostService
    {
        private HttpClient _httpClient;

        public PostService() { 
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<PostDto>> Get() {
            string url = "https://jsonplaceholder.typicode.com/posts";
            var result = await _httpClient.GetAsync(url);

            var body = await result.Content.ReadAsStringAsync();

            var opciones = new JsonSerializerOptions { 
                PropertyNameCaseInsensitive = true
            };

            var post =  JsonSerializer.Deserialize<IEnumerable<PostDto>>(body, opciones);
            return post;
        }
    }
}
