using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapiScopeSample.Exceptions;
using webapiScopeSample.interfaces;
using webapiScopeSample.models;

namespace webapiScopeSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {

        private IDatastoreProvider _datastoreProvider;
        private ILogger<RedisController> _logger;
        public RedisController(IDatastoreProvider datastoreProvider, ILogger<RedisController> logger)
        {
            _datastoreProvider = datastoreProvider;
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            string data = await _datastoreProvider.GetCache("weathermodel");

            if (data == null)
            {
                throw new NotFoundException("No data found");
            }
            return data;
        }

        [HttpPost]
        public async Task<bool> Add(WeatherModel weatherModel)
        {
            bool added = await _datastoreProvider.SetCache("weathermodel", weatherModel);

            if (added)
            {
                throw new NotFoundException("No data found");
            }
            return added;
        }
    }
}
