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
        private static string _language = "pl-pl";
        static async Task Main()
        {
            Console.WriteLine("Podaj nazwę miejscowości: "+Environment.NewLine);
            string query = Console.ReadLine();

            int resultCounter = 1;

            var cities = new List<City>(await GetWeatherHelper.GetCitiesAsync(query, _language));

            Console.WriteLine("Wybierz jeden z poniższych wyników: ");
            foreach (var c in cities)
            {
                Console.WriteLine($"{resultCounter}. {c.LocalizedName}, {c.AdministrativeArea.LocalizedName}, {c.Country.LocalizedName}" + Environment.NewLine);
                resultCounter++;
            }

            Console.Write("Wpisz numer i potwierdź klawiszem ENTER: ");
            int.TryParse(Console.ReadLine(), out int selectedNumber);
            City selectedCity = cities[selectedNumber - 1];

            var currentConditions = await GetWeatherHelper.GetCurrentConditions(selectedCity.Key, _language);

            Console.WriteLine($"\n Wybrałeś {selectedCity.LocalizedName}, {selectedCity.AdministrativeArea.LocalizedName}, {selectedCity.Country.LocalizedName}. Jest {currentConditions.LocalObservationDateTime:g} \n " +
                $"{currentConditions.WeatherText}, {currentConditions.Temperature.Metric.Value}°{currentConditions.Temperature.Metric.Unit}" +
                $"({currentConditions.Temperature.Imperial.Value}°{currentConditions.Temperature.Imperial.Unit})");
        }       
    }
}
