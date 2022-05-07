using System;
using System.Threading.Tasks;
using photo_project_api.Controllers;
using photo_project_api.Models;

namespace photo_project_services
{
    public interface IAlbumService
    {
        public Album GetAlbumById(int id);
        public void PrintAlbum(Album album);
    }

    public class AlbumService : IAlbumService
    {
        private readonly IAlbumController _albumController;

        public AlbumService(IAlbumController albumController)
        {
            _albumController = albumController;
        }

        public async Task<Album> GetAlbumByIdAsync(int id)
        {
            var albumResult = _albumController.GetByIdAsync(id).Result;

            return albumResult;
        }

        public Album GetAlbumById(int id)
        {
            var albumResult = GetAlbumByIdAsync(id);

            return albumResult.Result;
        }

        public void PrintAlbum(Album album)
        {
            Console.WriteLine(album.ToString());
        }
    }
}
