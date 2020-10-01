using Math.RabbitMQ.Model;
using Microsoft.Extensions.Configuration;
using System;

namespace Math.RabbitMQ.Extensions
{
    public static class QueueConfigExtension
    {
        public static QueueConfigModel GetQueueConfig(this IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var serviceConfig = new QueueConfigModel
            {
                HostName = configuration.GetValue<string>("RabbitMQ:HostName"),
                UserName = configuration.GetValue<string>("RabbitMQ:UserName"),
                Password = configuration.GetValue<string>("RabbitMQ:Password"),
                QueueName = configuration.GetValue<string>("RabbitMQ:QueueName")
            };

            return serviceConfig;
        }
    }
}
