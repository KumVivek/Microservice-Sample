using Automatonymous.Contexts;
using MassTransit;
using Math.Operation.Api.Contract;
using Math.Operation.Api.ViewModels;
using Math.RabbitMQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Math.Operation.Api.Services
{
    public class QueueMessageService: IQueueMessageService
    {
        private readonly QueueConfigModel _queueConfig;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        public QueueMessageService(QueueConfigModel queueConfig, ISendEndpointProvider sendEndpointProvider)
        {
            _queueConfig = queueConfig;
            _sendEndpointProvider = sendEndpointProvider;
        }

        public void SendMessageToQueue(AddModel addModel, double sum)
        {
            var endpoint =  _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{_queueConfig.QueueName}")).Result;
            endpoint.Send(ConstructMessageObject(addModel,sum)).Wait();
        }

        private Message ConstructMessageObject(AddModel addModel, double sum)
        {
            return new Message{
                FirstNumber = addModel.Number1,
                SecondNumber = addModel.Number2,
                Sum = sum
            };
        }
    }
}
