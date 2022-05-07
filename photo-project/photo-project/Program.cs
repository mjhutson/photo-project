using Autofac;
using System;

namespace photo_project
{
    public class Program
    {
        public static void Main()
        {
            var startup = new Startup();

            var container = startup.GetContainer();

            using var scope = container.BeginLifetimeScope();
            var job = scope.Resolve<IAlbumJobs>();

            job.GetAlbumFromUserInput();

            Console.WriteLine("Complete");
        }
    }
}
