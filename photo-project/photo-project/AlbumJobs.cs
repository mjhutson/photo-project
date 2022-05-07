using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using photo_project_api.Controllers;
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
