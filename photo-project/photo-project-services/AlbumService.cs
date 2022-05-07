using System;
using photo_project_api.Controllers;
using photo_project_api.Models;

namespace photo_project_services
{
    public interface IAlbumService
    {
        public Album GetAlbumById(int id);

    public class AlbumService : IAlbumService
    {
        private readonly IAlbumController _albumController;

        public AlbumService(IAlbumController albumController)
        {
            _albumController = albumController;
        }

        public Album GetAlbumById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
