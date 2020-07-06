using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Lib.Models
{
    public class Temperature
    {
        public TempUnit Metric { get; set; }
        public TempUnit Imperial { get; set; }
    }
}
