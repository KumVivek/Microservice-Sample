using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Math.Api.Base.Base;
using Math.Consul.Extensions;
using Math.Operation.Api.Contract;
using Math.Operation.Api.Services;
using Math.RabbitMQ.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Math.Operation.Api
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
            services.AddRabbitMQServices(queueConfig);
            services.AddScoped<IMathServices, MathServices>();
            services.AddScoped<IQueueMessageService, IQueueMessageService>(s=> new QueueMessageService(queueConfig,s.GetService<ISendEndpointProvider>()));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app)
        {
            base.Configure(app);
        }
    }
}
