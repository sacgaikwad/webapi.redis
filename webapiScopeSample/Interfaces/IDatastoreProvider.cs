using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapiScopeSample.models;

namespace webapiScopeSample.interfaces
{
    public interface IDatastoreProvider
    {
        Task<bool> SetCache(string key, WeatherModel model);
        Task<string> GetCache(string key);
    }
}
