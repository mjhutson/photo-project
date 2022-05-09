using AutoFixture;
using FluentAssertions;
using photo_project_api.Models;
using Xunit;

namespace photo_project_tests.apitests.ModelTests
{
    public class PhotoTests
    {
        private readonly Photo _sut;
        private readonly string _expectedPhotoAlbumString;
        private readonly string _expectedPhotoString;


        public PhotoTests()
        {
            var fixture = new Fixture();

            _sut = fixture.Create<Photo>();

            _expectedPhotoAlbumString = $"\tPhoto Id: {_sut.Id}\n"
                + $"\t\tTitle: {_sut.Title}\n"
                + $"\t\tUrl: {_sut.Url}\n"
                + $"\t\tThumbnailUrl: {_sut.ThumbnailUrl}\n";

            _expectedPhotoString = $"Album Id: {_sut.AlbumId}\n"
                + $"Photo Id: {_sut.Id}\n"
                + $"Title: {_sut.Title}\n"
                + $"Url: {_sut.Url}\n"
                + $"ThumbnailUrl: {_sut.ThumbnailUrl}\n";
        }

        [Fact]
        public void ToPhotoStringShouldReturnExpectedString()
        {
            _sut.ToString().Should().Be(_expectedPhotoAlbumString);
        }
    }
}
