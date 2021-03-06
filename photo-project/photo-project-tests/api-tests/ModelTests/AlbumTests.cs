using AutoFixture;
using FluentAssertions;
using photo_project_api.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace photo_project_tests.apitests.ModelTests
{
    public class AlbumTests
    {
        private readonly Album _sut;
        private readonly string _expectedAlbumString;
        private readonly string _expectedEmptyAlbumString;

        public AlbumTests()
        {
            var fixture = new Fixture();

            _sut = fixture.Create<Album>();

            _expectedAlbumString = $"Album Id: {_sut.Id}"
                + Environment.NewLine
                + CreatePhotoStrings();

            _expectedEmptyAlbumString = $"Album Id: {_sut.Id}"
                + Environment.NewLine
                + "Empty Album";
        }

        private string CreatePhotoStrings()
        {
            var photoStrings = string.Empty;

            foreach(var photo in _sut.Photos)
            {
                photoStrings += photo.ToString();
            }

            return photoStrings;
        }

        [Fact]
        public void ToStringShouldReturnExpectedString()
        {
            _sut.ToString().Should().Be(_expectedAlbumString);
        }

        [Fact]
        public void ToStringShouldReturnExpectedStringForEmptyPhotoList()
        {
            _sut.Photos = new List<Photo>();

            _sut.ToString().Should().Be(_expectedEmptyAlbumString);
        }
    }
}
