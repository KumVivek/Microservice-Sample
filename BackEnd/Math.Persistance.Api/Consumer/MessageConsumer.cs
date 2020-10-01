using MassTransit;
using Math.Persistance.Api.Contracts;
using Math.Persistance.Api.ViewModels;
using Math.RabbitMQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Math.Persistance.Api.Consumer
{
    public class MessageConsumer : IConsumer<Message>
    {
        private readonly IFileService _fileService;

        public MessageConsumer(IFileService fileService)
        {
            _fileService = fileService;
        }

        /// <summary>
        /// This method will trigger when queue recieve any message.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<Message> context)
        {
            var constructedMessage = ConstructResultModel(context.Message);
            _fileService.SaveResult(constructedMessage);
        }

        /// <summary>
        /// This method create an instance of result model and feed the values from the consumer context model.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private ResultModel ConstructResultModel(Message message)
        {
            return new ResultModel {
                EventTime = DateTime.UtcNow,
                Number2 = message.SecondNumber,
                Result = message.Sum,
                Number1 = message.FirstNumber,
            };
        }
    }
}
