using MassTransit;
using Math.RabbitMQ.Bus;
using Math.RabbitMQ.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Math.RabbitMQ.Extensions
{
    public static class RabbitMQService
    {
        public static IServiceCollection AddRabbitMQServices(this IServiceCollection services, QueueConfigModel queueConfigModel)
        {
            services.AddMassTransit(cfg =>
            {
                cfg.AddBus(provider => BusService.ConfigureBusService(provider, queueConfigModel));
            });

            return services;
        }

        public static IServiceCollection AddRabbitMQConsumerServices<T>(this IServiceCollection services, QueueConfigModel queueConfigModel) where T:class, IConsumer
        {

            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<T>();
                cfg.AddBus(provider => BusService.ConfigureBusService(provider, queueConfigModel, (cfg, host) =>
                {
                    cfg.ReceiveEndpoint(queueConfigModel.QueueName, ep =>
                    {
                        ep.ConfigureConsumer<T>(provider);
                    });
                }));

            });
            services.AddMassTransitHostedService();

            return services;
        }
    }
}
