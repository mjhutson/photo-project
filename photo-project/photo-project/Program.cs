using Autofac;
using Autofac.Core;

namespace photo_project
{
    public class Program
    {
        public static void Main()
        {
            var startup = new Startup();

            Container container = startup.GetContainer();

            using var scope = container.BeginLifetimeScope();
            var job = scope.Resolve<IAlbumJobs>();

            job.GetAlbumFromUserInput();
        }
    }
}
