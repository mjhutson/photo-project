using Autofac;
using Microsoft.Extensions.Configuration;
using photo_project_api.Controllers;
using photo_project_api.Wrappers;
using photo_project_services;
using photo_project_services.Wrappers;
using System;
using System.Net.Http;

namespace photo_project
{
    public class Startup
    {
        private readonly ContainerBuilder _containerBuilder;
        private readonly IContainer _container;

        public Startup()
        {
            _containerBuilder = new ContainerBuilder();
            SetupContainer(_containerBuilder);
            _container = _containerBuilder.Build();
        }

        public void SetupContainer(ContainerBuilder builder)
        {
            builder.Register(c => new HttpClient()
            {
                BaseAddress = new Uri(GetConfiguration()["AlbumApi:Endpoint"])
            })
            .Named<HttpClient>(GetConfiguration()["AlbumApi:ClientName"])
            .SingleInstance();
            builder.Register(c => new HttpClientWrapper(c.ResolveNamed<HttpClient>(GetConfiguration()["AlbumApi:ClientName"])))
            .InstancePerDependency().As<IHttpClientWrapper>();
            builder.RegisterType<DeserializationWrapper>().As<IDeserializationWrapper>();
            builder.RegisterType<AlbumJobs>().As<IAlbumJobs>();
            builder.RegisterType<AlbumService>().As<IAlbumService>();
            builder.RegisterType<AlbumController>().As<IAlbumController>();
            builder.RegisterType<ConsoleWrapper>().As<IConsoleWrapper>();
            builder.RegisterType<UserInputService>().As<IUserInputService>();

        }

        public IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public IContainer GetContainer(){
            return _container;
        }
    }
}
