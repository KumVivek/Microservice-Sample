using Consul;
using Math.Consul.Models;
using Math.Consul.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Math.Consul.Extensions
{
    public static class ServiceDiscoveryExtensions
    {
        public static void RegisterConsulServices(this IServiceCollection services, ServiceConfigModel serviceConfigModel)
        {
            if (serviceConfigModel == null)
            {
                throw new ArgumentNullException(nameof(serviceConfigModel));
            }

            var consulClient = CreateConsulClient(serviceConfigModel);

            services.AddSingleton(serviceConfigModel);
            services.AddSingleton<IHostedService, ServiceDiscoveryHostedService>();
            services.AddSingleton<IConsulClient, ConsulClient>(p => consulClient);
        }

        private static ConsulClient CreateConsulClient(ServiceConfigModel serviceConfig)
        {
            return new ConsulClient(config =>
            {
                config.Address = serviceConfig.ServiceDiscoveryAddress;
            });
        }
    }
}
