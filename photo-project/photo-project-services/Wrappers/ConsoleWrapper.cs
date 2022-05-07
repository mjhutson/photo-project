using System;

namespace photo_project_services.Wrappers
{
    public interface IConsoleWrapper
    {
        public string ReadLine();
        public void PromptForInput();
        public void PromptForValidInput();
        public void DisplayId(int id);
    }
    // Wrapper class to test the input validation with
    public class ConsoleWrapper : IConsoleWrapper
    {
        public void DisplayId(int id)
        {
            Console.WriteLine($"Getting album {id}");
        }

        public void PromptForInput()
        {
            Console.WriteLine("Please enter an album id number: ");
        }

        public void PromptForValidInput()
        {
            Console.WriteLine("Invalid input. Please enter an integer: ");
        }

        public string ReadLine()
        {
            var x = Console.ReadLine();
            return x;
        }
    }
}
