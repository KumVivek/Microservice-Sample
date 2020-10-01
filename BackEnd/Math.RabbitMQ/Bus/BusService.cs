using MassTransit;
using MassTransit.RabbitMqTransport;
using Math.RabbitMQ.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Math.RabbitMQ.Bus
{
    public static class BusService
    {
        /// <summary>
        /// Select rabbitmq as transport for the service bus.
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="queueConfigModel"></param>
        /// <param name="registrationAction"></param>
        /// <returns></returns>
        public static IBusControl ConfigureBusService(IServiceProvider provider, QueueConfigModel queueConfigModel, Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null)
        {
            return MassTransit.Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(queueConfigModel.HostName), hst =>
                {
                    hst.Username(queueConfigModel.UserName);
                    hst.Password(queueConfigModel.Password);
                });

                cfg.ConfigureEndpoints(provider);

                registrationAction?.Invoke(cfg, host);
            });
        }
    }
}
