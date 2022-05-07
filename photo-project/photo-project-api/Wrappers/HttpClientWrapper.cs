using System.Net.Http;
using System.Threading.Tasks;

namespace photo_project_api.Wrappers
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> GetByIdAsync(int id);
    }

    // Wrapper class to mock responses for the controller
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _client;

        public HttpClientWrapper(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("albumClient");
            
        }

        public async Task<HttpResponseMessage> GetByIdAsync(int albumId)
        {
            return await _client.GetAsync($"{_client.BaseAddress}?albumId={albumId}");
        }
    }
}
