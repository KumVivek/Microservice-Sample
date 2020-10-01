using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Math.Persistance.Api.Contracts;
using Math.Persistance.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Math.Persistance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("GetFileContent")]
        public  IActionResult GetFileContent()
        {
           
            try
            {
                var resultModel = _fileService.GetFileContent();
                return Ok(new JsonResult(resultModel));
            }
            catch (Exception Ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,Ex);
            }
        }
    }
}