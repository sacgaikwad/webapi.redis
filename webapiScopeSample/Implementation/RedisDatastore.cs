using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using webapiScopeSample.interfaces;
using webapiScopeSample.models;

namespace webapiScopeSample.implementation
{
    public class RedisDatastore : IDatastoreProvider
    {
        IDistributedCache _distributedCache;
        ILogger<RedisDatastore> _logger;
        public RedisDatastore(ILogger<RedisDatastore> logger, IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
            _logger = logger;
        }
        public async Task<string> GetCache(string key)
        {
            string str = await _distributedCache.GetStringAsync(key);

            if (str == null)
            {
                return null;
            }

            return JsonSerializer.Deserialize<string>(str);
        }

        public async Task<bool> SetCache(string key, WeatherModel model)
        {
            string str = JsonSerializer.Serialize<WeatherModel>(model);

            await _distributedCache.SetStringAsync("weatherModel", str);

            return true;
        }
    }
}
