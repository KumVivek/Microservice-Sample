using Math.Operation.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Math.Operation.Api.Contract
{
    public interface IQueueMessageService
    {
       void SendMessageToQueue(AddModel addModel, double sum);
    }
}
