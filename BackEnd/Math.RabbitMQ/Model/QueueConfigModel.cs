using System;
using System.Collections.Generic;
using System.Text;

namespace Math.RabbitMQ.Model
{
    public class QueueConfigModel
    {
        /// <summary>
        /// Url of the rabbitmq.
        /// </summary>
        public string HostName { get; set; }
        /// <summary>
        /// Username
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Queue name. This queue is responsible for processing of message.
        /// </summary>
        public string QueueName { get; set; }
    }
}
