using Math.Operation.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Math.Operation.Api.Contract
{
    public interface IMathServices
    { 
        /// <summary>
        /// This method will perform the add operation on the given input in addModel.
        /// </summary>
        /// <param name="addModel"></param>
        /// <returns>double</returns>
        double Add(AddModel addModel);
    }
}
