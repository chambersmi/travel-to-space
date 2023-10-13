using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] // Adds errors to ModelState
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        
    }
}