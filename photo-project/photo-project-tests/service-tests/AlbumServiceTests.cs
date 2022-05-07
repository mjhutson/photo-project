using System.Linq;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using photo_project_api.Controllers;
using photo_project_api.Models;
using photo_project_services;
using Xunit;

namespace photo_project_tests
{
    public class AlbumServiceTests
    {
        private readonly IAlbumController _albumController;
        private readonly int _expectedAlbumId;
        private readonly Album _expectedAlbum;
        private readonly Fixture _fixture;

        private readonly AlbumService _sut;

        public AlbumServiceTests()
        {
            _fixture = new Fixture();

            _expectedAlbumId = _fixture.Create<int>();

            _expectedAlbum = CreateAlbumWithId(_expectedAlbumId);

            _albumController = Substitute.For<IAlbumController>();
            _albumController.GetByIdAsync(_expectedAlbumId).Returns(_expectedAlbum);

            _sut = new AlbumService(_albumController);
        }

        private Album CreateAlbumWithId(int id)
        {
            return new Album()
            {
                Id = id,
                Photos = _fixture.Build<Photo>()
                    .With(photo => photo.AlbumId, id)
                    .CreateMany()
                    .ToList()
            };
        }


        [Fact]
        public void GetByAlbumIdShouldReturnExpectedAlbum()
        {
            var actualResult = _sut.GetAlbumById(_expectedAlbumId);

            actualResult.Should().BeEquivalentTo(_expectedAlbum);
        }
    }
}
