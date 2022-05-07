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

            _expectedPhotoAlbumString = $"Photo Id: {_sut.Id}"
                + $"\n{_sut.Title}"
                + $"\n{_sut.Url}"
                + $"\n{_sut.ThumbnailUrl}"
                + "\n";

            _expectedPhotoString = $"Album Id: {_sut.AlbumId}"
                + $"\n{_expectedPhotoAlbumString}";
        }

        [Fact]
        public void ToAlbumPhotoStringShouldReturnExpectedString()
        {
            _sut.ToAlbumPhotoString().Should().Be(_expectedPhotoAlbumString);
        }


        [Fact]
        public void ToStringShouldReturnExpectedString()
        {
            _sut.ToString().Should().Be(_expectedPhotoString);
        }
    }
}
