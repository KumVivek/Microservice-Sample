using Math.Operation.Api.Contract;
using Math.Operation.Api.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Math.Operation.Api.Services
{
    public class MathServices: IMathServices
    {
        private readonly IQueueMessageService _queueMessageService;
        public MathServices(IQueueMessageService queueMessageService)
        {
            _queueMessageService = queueMessageService;
        }

        /// <summary>
        /// This method will perform the add operation on the given input in addModel.
        /// </summary>
        /// <param name="addModel"></param>
        /// <returns>double</returns>
        public double Add(AddModel addModel)
        {
            try
            {
                var sum =  addModel.Number1 + addModel.Number2;
                _queueMessageService.SendMessageToQueue(addModel, sum);
                return sum;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
