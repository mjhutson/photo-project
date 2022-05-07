using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using photo_project_api.Models;

namespace photo_project_api.Wrappers
{
    public interface IDeserializationWrapper
    {
        public Task<List<Photo>> DeserializeJson(HttpResponseMessage httpResponseMessage);
    }
    public class DeserializationWrapper : IDeserializationWrapper
    {
        public async Task<List<Photo>> DeserializeJson(HttpResponseMessage httpResponseMessage)
        {
            var content = httpResponseMessage.Content;
            return await content.ReadFromJsonAsync<List<Photo>>();
        }
    }
}
