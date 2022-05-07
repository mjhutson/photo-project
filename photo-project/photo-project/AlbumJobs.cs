using photo_project_services;

namespace photo_project
{
    public interface IAlbumJobs
    {
        void GetAlbumFromUserInput();
    }
    public class AlbumJobs : IAlbumJobs
    {
        private readonly IAlbumService _albumService;
        private readonly IUserInputService _userInputService;

        public AlbumJobs(IAlbumService albumService, IUserInputService userInputService)
        {
            _albumService = albumService;
            _userInputService = userInputService;
        }

        public void GetAlbumFromUserInput()
        {
            var userInput = _userInputService.GetAlbumIdFromUser();
            var album = _albumService.GetAlbumById(userInput);
            _albumService.PrintAlbum(album);
        }
    }
}
