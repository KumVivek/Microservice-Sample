using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Math.Api.Base.Base;
using Math.Consul.Extensions;
using Math.Persistance.Api.Consumer;
using Math.Persistance.Api.Contracts;
using Math.Persistance.Api.Services;
using Math.RabbitMQ.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Math.Persistance.Api
{
    public class Startup:BaseStartup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            var serviceConfig = Configuration.GetServiceConfig();
            services.RegisterConsulServices(serviceConfig);
            var queueConfig = Configuration.GetQueueConfig();
            services.AddRabbitMQConsumerServices<MessageConsumer>(queueConfig);
            services.AddScoped<IFileService, FileService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app)
        {
            base.Configure(app);
        }
    }
}
