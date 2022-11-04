using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapiScopeSample.models
{
    public class WeatherModel
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string WeatherCondition { get; set; }
    }
}
