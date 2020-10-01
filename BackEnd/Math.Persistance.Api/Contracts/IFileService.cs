using Math.Persistance.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Math.Persistance.Api.Contracts
{
    public interface IFileService
    {
        (bool success, string message) SaveResult(ResultModel resultModel);
        List<ResultModel> GetFileContent();
    }
}
