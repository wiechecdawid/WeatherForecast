using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using WeatherForecast.Lib.Models;
using Newtonsoft.Json;
using System.Linq;

namespace WeatherForecast.Lib.Helpers
{
    /// <summary>
    /// A class created to 
    /// </summary>
    public class GetWeatherHelper
    {
        public const string BaseUrl = "http://dataservice.accuweather.com/";
        public const string ApiKey = "wcqknZcsC5F15AuazCPULZZT7ZkmB9Fz";
        public const string Autocomplete = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language={2}";        

        public static async Task<List<City>> GetCitiesAsync(string query, string language)
        {
            List<City> cities = new List<City>();

            string url = BaseUrl + string.Format(Autocomplete, ApiKey, query, language);

            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }
    }
}
