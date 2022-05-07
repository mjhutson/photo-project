using photo_project_api.Models;

namespace photo_project_api.Controllers
{
    public interface IAlbumController
    {
        public Album GetById(int id);
    }

    public class AlbumController : IAlbumController
    {
        public Album GetById(int id)
        {
            return new Album();
        }
    }
}
