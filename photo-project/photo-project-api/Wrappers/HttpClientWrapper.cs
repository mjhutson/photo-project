using System;
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

        public HttpClientWrapper(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> GetByIdAsync(int albumId)
        {
            var uri = new Uri($"{_client.BaseAddress}/?albumId={albumId}");

            var response = await _client.GetAsync(uri);

            return response;
        }
    }
}
