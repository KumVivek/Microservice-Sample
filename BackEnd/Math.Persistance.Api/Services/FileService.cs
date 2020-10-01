using Math.Persistance.Api.Contracts;
using Math.Persistance.Api.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Math.Persistance.Api.Services
{
    public class FileService:IFileService
    {
        public FileService()
        {

        }

        public List<ResultModel> GetFileContent()
        {
            var filePath = GetFilePath();
            if (File.Exists(filePath))
            {
                var fileContent = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<ResultModel>>(fileContent);
            }
            return new List<ResultModel>();
        }

        public (bool success, string message) SaveResult(ResultModel resultModel)
        {
            try
            {
                string filePath = GetFilePath();
                if (File.Exists(filePath))
                {
                    var fileString = File.ReadAllText(filePath);
                    var list = JsonConvert.DeserializeObject<List<ResultModel>>(fileString);
                    list.Add(resultModel);
                    File.WriteAllText(filePath, JsonConvert.SerializeObject(list));
                    return (true, "Date written successfully.");
                }
                List<ResultModel> resultModels = new List<ResultModel>
                {
                    resultModel
                };
                File.WriteAllText(filePath, JsonConvert.SerializeObject(resultModels));
                return (true, "Date written successfully.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GetFilePath()
        {
            string fileName = "FileResult.txt";
            string fileDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(fileDirectory, fileName);
            return filePath;
        }

    }
}
