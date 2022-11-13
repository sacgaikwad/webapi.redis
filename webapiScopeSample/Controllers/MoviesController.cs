using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapiScopeSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet("v1/get")]
        public IEnumerable<string> Getv1()
        {
            return new string[] {
                "V1.value1",  
                "V1.value2"
            };
        }
        [HttpGet("v2/get")]
        public IEnumerable<string> Getv2()
        {
            return new string[] {
                "V2.value1",  
            "V2.value2"
            };
        }
    }
}
