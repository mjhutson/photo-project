using photo_project_services.Wrappers;

namespace photo_project_services
{
    public interface IUserInputService
    {
        public int GetAlbumIdFromUser();
    }

    public class UserInputService : IUserInputService
    {
        // Constrining the user to 3 retries to prevent the potential for inf. loops
        private const int MaxRetries = 3;

        private readonly IConsoleWrapper _consoleWrapper;

        public UserInputService(IConsoleWrapper consoleWrapper)
        {
            _consoleWrapper = consoleWrapper;
        }

        public int GetAlbumIdFromUser()
        {
            var userHasEnteredValidAlbumId = false;
            var retries = 0;

            _consoleWrapper.PromptForInput();

            do
            {
                if (int.TryParse(_consoleWrapper.ReadLine(), out var id))
                {
                    _consoleWrapper.DisplayId(id);
                    return id;
                }
                else
                {
                    retries++;
                    _consoleWrapper.PromptForValidInput();
                }
            } while (!userHasEnteredValidAlbumId || retries < MaxRetries);

            return -1;
        }
    }
}
