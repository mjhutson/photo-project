using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using photo_project_api.Controllers;
using photo_project_services;

namespace photo_project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services, string baseUri)
        {

            services.AddHttpClient("albumClient", client =>
            {
                client.BaseAddress = new Uri(baseUri);
            });

            services.AddTransient<IAlbumController, AlbumController>();
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<IUserInputService, UserInputService>();

            var container = services.BuildServiceProvider(true);

            IServiceScope scope = container.CreateScope();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}