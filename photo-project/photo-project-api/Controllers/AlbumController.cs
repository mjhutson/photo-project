using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using photo_project_api.Models;
using photo_project_api.Wrappers;


namespace photo_project_api.Controllers
{
    public interface IAlbumController
    {
        public Task<Album> GetByIdAsync(int id);
    }

    public class AlbumController : IAlbumController 
    {
        private readonly IHttpClientWrapper _httpClient;
        private readonly IDeserializationWrapper _deserializer;

        public AlbumController(IHttpClientWrapper httpClient, IDeserializationWrapper deserializer)
        {
            _httpClient = httpClient;
            _deserializer = deserializer;
        }

        public async Task<Album> GetByIdAsync(int albumId)
        {
            var response = await _httpClient.GetByIdAsync(albumId);


            return Deserialize(response, albumId);
            
        }

        public Album Deserialize(HttpResponseMessage httpResponseMessage, int id)
        {
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var photos = _deserializer.DeserializeJson(httpResponseMessage);

                return new Album
                {
                    Id = id,
                    Photos = photos
                };
            }
            return new Album();
        }
    }
}
