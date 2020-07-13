using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using WeatherForecast.Lib.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace WeatherForecast.Lib.Helpers
{
    /// <summary>
    /// A class created to receive data from AccuWeather API.
    /// </summary>
    public class GetWeatherHelper
    {
        public const string BaseUrl = "http://dataservice.accuweather.com/";
        public const string ApiKey = "wcqknZcsC5F15AuazCPULZZT7ZkmB9Fz";
        public const string AutocompleteUrl = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language={2}";
        public const string currentConditionsUrl = "currentconditions/v1/{0}?apikey={1}&language={2}";
        public const string forecast12hUrl = "forecasts/v1/hourly/12hour/{0}?apikey={1}&language={2}&metric=true";
        public const string forecast5dUrl = "forecasts/v1/daily/5day/{0}?apikey={1}&language={2}&metric=true";

        /// <summary>
        /// Provides a list of cities based on user's input.
        /// </summary>
        /// <param name="query">input provided by an user - autocomplete.</param>
        /// <param name="language">PL by default (TODO: implement English version)</param>
        /// <returns>Asynchronous list of cities</returns>
        public static async Task<List<City>> GetCitiesAsync(string query, string language)
        {
            List<City> cities = new List<City>();

            string url = BaseUrl + string.Format(AutocompleteUrl, ApiKey, query, language);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }

        /// <summary>
        /// Performs a call to the API in order to retrieve current weather conditions for selected city
        /// </summary>
        /// <param name="cityKey">Key used to identify selected city</param>
        /// <param name="language">Selected language</param>
        /// <returns>Current weather conditions for selected city</returns>
        public static async Task<CurrentConditions> GetCurrentConditions(string cityKey, string language)
        {
            var currentConditions = new CurrentConditions();

            string url = BaseUrl + string.Format(currentConditionsUrl, cityKey, ApiKey, language);

            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                currentConditions = JsonConvert.DeserializeObject<List<CurrentConditions>>(json).FirstOrDefault();
            }

            return currentConditions;
        }

        /// <summary>
        /// Returns forecast for the next 12 hours
        /// </summary>
        public async Task<List<ForecastedConditions>> Get12hrsForecast(string cityKey, string language)
        {
            var conditions = new List<ForecastedConditions>();

            string url = BaseUrl + string.Format(forecast5dUrl, cityKey, ApiKey, language);

            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                string json = await response.Content.ReadAsStringAsync();

                conditions = JsonConvert.DeserializeObject<List<ForecastedConditions>>(json);
            }
            return conditions;
        }

        public async Task<FiveDaysForecast> Get5DaysForecast(string cityKey, string language)
        {
            var conditions = new FiveDaysForecast();

            string url = BaseUrl + string.Format(forecast12hUrl, cityKey, ApiKey, language);

            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                string json = await response.Content.ReadAsStringAsync();

                conditions = JsonConvert.DeserializeObject<FiveDaysForecast>(json);
            }
            return conditions;
        }
    }
}
