using AutoFixture;
using FluentAssertions;
using photo_project_api.Models;
using System;
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
                + Environment.NewLine
                + $"Title: {_sut.Title}"
                + Environment.NewLine
                + $"Url: {_sut.Url}"
                + Environment.NewLine
                + $"ThumbnailUrl: {_sut.ThumbnailUrl}"
                + Environment.NewLine;

            _expectedPhotoString = $"Album Id: {_sut.AlbumId}"
                + Environment.NewLine
                + $"Photo Id: {_sut.Id}"
                + Environment.NewLine
                + $"Title: {_sut.Title}"
                + Environment.NewLine
                + $"Url: {_sut.Url}"
                + Environment.NewLine
                + $"ThumbnailUrl: {_sut.ThumbnailUrl}"
                + Environment.NewLine;
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
