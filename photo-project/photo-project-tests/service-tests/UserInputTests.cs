using AutoFixture;
using FluentAssertions;
using NSubstitute;
using photo_project_services;
using photo_project_services.Wrappers;
using Xunit;

namespace photo_project_tests.servicetests
{
    public class UserInputTests
    {
        private const int FallThroughId = -1;

        private readonly IConsoleWrapper _consoleWrapper;

        private readonly UserInputService _sut;

        private readonly int _expectedId;

        public UserInputTests()
        {
            var fixture = new Fixture();

            _expectedId = fixture.Create<int>();

            _consoleWrapper = Substitute.For<ConsoleWrapper>();
            _consoleWrapper.ReadLine().Returns(_expectedId.ToString());

            _sut = new UserInputService(_consoleWrapper);
        }


        [Fact]
        public void ShouldCallPromptForInputOnce()
        {
            _sut.GetAlbumIdFromUser();

            _consoleWrapper.Received(1).PromptForInput();
        }

        [Fact]
        public void ShouldCallDisplayIdOnceForValidInput()
        {
            _sut.GetAlbumIdFromUser();

            _consoleWrapper.Received(1).DisplayId(Arg.Any<int>());
        }

        [Fact]
        public void ShouldNotCallPromptForValidInputForValidInput()
        {
            _sut.GetAlbumIdFromUser();

            _consoleWrapper.DidNotReceive().PromptForValidInput();
        }

        [Fact]
        public void ShouldReturnExpectedIdForValidInput()
        {
            _sut.GetAlbumIdFromUser().Should().Be(_expectedId);
        }

        [Fact]
        public void ShouldCallPromptForValidInputForInvalidInput()
        {

            _consoleWrapper.ReadLine().Returns("Not a number");

            _sut.GetAlbumIdFromUser();

            _consoleWrapper.Received(3).PromptForValidInput();
        }

        [Fact]
        public void ShouldNotCallPDisplayIdForInvalidInput()
        {

            _consoleWrapper.ReadLine().Returns("Not a number");

            _sut.GetAlbumIdFromUser();

            _consoleWrapper.DidNotReceive().DisplayId(Arg.Any<int>());
        }


        [Fact]
        public void ShouldReturnFallThroughIdForInvalidInput()
        {

            _consoleWrapper.ReadLine().Returns("Not a number");

            _sut.GetAlbumIdFromUser().Should().Be(FallThroughId);
        }
    }
}
