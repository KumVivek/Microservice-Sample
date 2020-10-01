using Math.Operation.Api.Contract;
using Math.Operation.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Math.Operation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        private readonly IMathServices _mathServices;
        public MathController(IMathServices mathServices)
        {
            _mathServices = mathServices;
        }

        /// <summary>
        /// This method will perform the add operation on the given input in addModel.
        /// </summary>
        /// <param name="addModel"></param>
        /// <returns>double</returns>

        [HttpPost("add")]
        public IActionResult Add([FromBody] AddModel addModel)
        {
            if (addModel is null)
            {
                throw new ArgumentNullException(nameof(addModel));
            }

            try
            {
                var result = _mathServices.Add(addModel);
                return Ok(new JsonResult(result));
            }
            catch (Exception Ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, Ex.Message);
            }
        }
    }
}