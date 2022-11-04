using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapiScopeSample.interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapiScopeSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstanceController : ControllerBase
    {
        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;
        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;
        public InstanceController(ITransientService transientService1,
            ITransientService transientService2,
            IScopedService scopedService1,
            IScopedService scopedService2,
            ISingletonService singletonService1,
            ISingletonService singletonService2)
        {

            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;

        }
        // GET: api/<InstanceController>
        [HttpGet]
        public Dictionary<string, string> Get()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            keyValuePairs.Add("TransientService1", _transientService1.GetOperationID().ToString());
            keyValuePairs.Add("TransientService2", _transientService2.GetOperationID().ToString());
            keyValuePairs.Add("ScopedService1", _scopedService1.GetOperationID().ToString());
            keyValuePairs.Add("ScopedService2", _scopedService2.GetOperationID().ToString());
            keyValuePairs.Add("SingletonService1", _singletonService1.GetOperationID().ToString());
            keyValuePairs.Add("SingletonService2", _singletonService2.GetOperationID().ToString());

            return keyValuePairs;

        }

        [HttpGet("{someException}")]
        public string Get(string someException)
        {
            throw new SomeException("user exception");
        }
    }
}
