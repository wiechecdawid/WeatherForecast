using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Lib.Models
{
    public class CurrentConditions
    {
        public DateTime LocalObservationTime { get; set; }
        public int EpochTime { get; set; }
        public string WeatherIcon { get; set; }
        public bool HasPrecitipation { get; set; }
        public object PrecipitationType { get; set; }
        public bool IsDayTime { get; set; }
        public Temperature Temperature { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }
}
