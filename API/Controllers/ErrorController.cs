using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //Override roots
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)] // Tell swagger to ignore this
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code) {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}