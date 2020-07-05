using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Lib.Helpers;
using WeatherForecast.Lib.Models;

namespace WeatherForecast.CLI
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Podaj nazwę miejscowości: "+Environment.NewLine);
            string query = Console.ReadLine();
            string language = "pl-pl";
            var cities = new List<City>(await GetWeatherHelper.GetCitiesAsync(query, language));
            foreach (var c in cities)
            {
                Console.WriteLine($"{c.LocalizedName}, {c.AdministrativeArea.LocalizedName}, {c.Country.LocalizedName}" + Environment.NewLine);
            }
        }       
    }
}
