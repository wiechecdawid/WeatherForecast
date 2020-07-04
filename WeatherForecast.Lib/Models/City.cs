using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Lib.Models
{
    public class City
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public Country Country { get; set; }
        public AdministrativeArea Area { get; set; }
    }
}
