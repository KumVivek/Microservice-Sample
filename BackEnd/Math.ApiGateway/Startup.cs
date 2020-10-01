using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using System;

namespace Math.ApiGateway
{
    public class Startup
    {
        private const string PolicyName = "AllowCors";

        public Startup(IWebHostEnvironment environment)
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder();
            builder.SetBasePath(environment.ContentRootPath)
                   .AddJsonFile("appsettings.json")
                   .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
                   .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public  void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(
                 options => options.AddPolicy(PolicyName,
                     builder =>
                     {
                         builder
                             .AllowAnyOrigin()
                             .WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS")
                             .AllowAnyHeader();
                     })
             );
            services.AddOcelot(Configuration).AddConsul();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app)
        {
            app.UseCors(PolicyName);
            await app.UseOcelot();
        }
    }
}
