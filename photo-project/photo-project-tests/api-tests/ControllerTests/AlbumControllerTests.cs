using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using photo_project_api.Controllers;
using photo_project_api.Models;
using photo_project_api.Wrappers;
using Xunit;

namespace photo_project_tests.apitests.ControllerTests
{
    public class AlbumControllerTests
    {
        private readonly IHttpClientWrapper _httpClient;
        private readonly int _expectedAlbumId;
        private readonly Album _expectedAlbum;
        private readonly HttpResponseMessage _expectedAlbumResponse;

        private readonly AlbumController _sut;

        public AlbumControllerTests()
        {
            var fixture = new Fixture();

            _expectedAlbumId = fixture.Create<int>();
            _expectedAlbum = fixture.Create<Album>();
            _expectedAlbumResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };

            _httpClient = Substitute.For<HttpClientWrapper>();
            _httpClient.GetByIdAsync(_expectedAlbumId).Returns(_expectedAlbumResponse);

            _sut = new AlbumController(_httpClient);
        }

        [Fact]
        public async Task GetByIdAsyncShouldReturnExpectedAlbumForValidQuery()
        {
            var actualResult = await _sut.GetByIdAsync(_expectedAlbumId);

            actualResult.Should().Be(_expectedAlbum);
        }

        [Fact]
        public async Task GetByIdAsyncShouldCallHttpClientOnceWithExpectedId()
        {
            await _sut.GetByIdAsync(_expectedAlbumId);

            await _httpClient.Received(1).GetByIdAsync(Arg.Any<int>());
            await _httpClient.Received(1).GetByIdAsync(_expectedAlbumId);
        }

        [Fact]
        public async Task GetByIdAsyncShouldReturnNewAlbumIfResponseIsNotSuccess()
        {
            var badResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound
            };
            _httpClient.GetByIdAsync(Arg.Any<int>()).Returns(badResponse);

            var actualResult = await _sut.GetByIdAsync(_expectedAlbumId);

            actualResult.Should().Be(new Album());
        }
    }
}
