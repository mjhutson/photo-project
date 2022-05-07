using System;
namespace photo_project
{
    public class Startup
    {
        private readonly ContainerBuilder _containerBuilder;
        private readonly Container _container;

        public Startup()
        {
            _containerBuilder = new ContainerBuilder();
            SetupContainer(_containerBuilder);
            _container = _builder.Build();
        }

        public void SetupContainer(ContainerBuilder builder)
        {
            builder.RegisterType<AlbumJobs>().As<IAlbumJobs>();
            builder.RegisterType<AlbumService>().As<IAlbumService>();
            builder.RegisterType<AlbumController>().As<IAlbumController>();
            builder.RegisterType<UserInputService>().As<IUserInputService>();
            builder.RegisterType<HttpClientWrapper>().As<IHttpClientWrapper>();
            builder.Register(c => new HttpClient()
            {
                BaseAddress = new Uri(GetConfiguration()["AlbumApi:Endpoint"])
            })
            .Named<HttpClient>(GetConfiguration()["AlbumApi:ClientName"])
            .SingleInstance();
        }

        public IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public Container GetContainer(){
            return _container;
        }
    }
}
