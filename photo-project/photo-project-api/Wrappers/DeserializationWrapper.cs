using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using photo_project_api.Models;

namespace photo_project_api.Wrappers
{
    public interface IDeserializationWrapper
    {
        public List<Photo> DeserializeJson(HttpResponseMessage httpResponseMessage);
    }
    public class DeserializationWrapper : IDeserializationWrapper
    {
        public List<Photo> DeserializeJson(HttpResponseMessage httpResponseMessage)
        {
            return JsonSerializer.Deserialize<List<Photo>>(httpResponseMessage.Content.ToString());
        }
    }
}
