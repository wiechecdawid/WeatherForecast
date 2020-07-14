using System;
using WeatherForecast.Lib.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using WeatherForecast.Lib.Helpers;

/// <summary>
/// A singleton class responsible for displaying and navigation of menu.
/// </summary>
public sealed class Menu
{
    private static Menu _instance = null;
    private static readonly object _lock = new object();
    private int _choice = -1;    
    Menu(){ Language = "pl-pl"; }
    public static Menu Instance
    {
        get
        {
            lock(_lock)
            {
               if(_instance == null) 
               {
                   _instance = new Menu();
               }
               return _instance;
            }
        }
    }
    public City City { get; set; }
    public string Language { get; set; }

    #region Methods

    /// <summary>
    /// A void method responsible for displaying and navigation througout menu options.
    ///</summary>
    public async Task NavigateAsync()
    {
        while(true)
        {
            System.Console.WriteLine("Witaj w konsolowej stacji pogodowej. Co chcesz zrobić?" + Environment.NewLine +
                                        "1. Ustaw miasto." + Environment.NewLine +
                                        "2. Aktualne warunki pogodowe." + Environment.NewLine +
                                        "3. Prognoza pogody." + Environment.NewLine +
                                        "4. Opuść program." + Environment.NewLine);
            Console.Write("Podaj numer odpowiadający wybranej opcji i potwierdź swój wybór klawiszem Enter: ");
            if(int.TryParse(Console.ReadLine(), out _choice))
            {
                if(Enum.IsDefined(typeof(Options), _choice - 1))
                {
                    var option = (Options)_choice -1;

                    switch(option)
                    {
                        case Options.SetCity:
                            City = await SetCityAsync();
                            break;
                        case Options.GetCurrentConditions:
                            await ShowCurrentConditionsAsync();
                            break;
                        case Options.GetForecast:
                            await ShowLatestForecastAsync();
                            break;
                        case Options.Quit:
                            Console.WriteLine("Dziękujemy za skorzystanie z aplikacji. Zapraszamy ponownie!");
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
    }

    public async Task<City> SetCityAsync()
    {
        Console.WriteLine("Podaj nazwę miejscowości: "+Environment.NewLine);
            string query = Console.ReadLine();

            int resultCounter = 1;

            var cities = new List<City>(await GetWeatherHelper.GetCitiesAsync(query, Language));

            Console.WriteLine("Wybierz jeden z poniższych wyników: ");
            foreach (var c in cities)
            {
                Console.WriteLine($"{resultCounter}. {c.LocalizedName}, {c.AdministrativeArea.LocalizedName}, {c.Country.LocalizedName}" + Environment.NewLine);
                resultCounter++;
            }

            Console.Write("Wpisz numer i potwierdź klawiszem ENTER: ");
            int.TryParse(Console.ReadLine(), out int selectedNumber);

            Console.WriteLine("Miasto zostało ustawione.");

            return cities[selectedNumber - 1];
    }

    /// <summary>
    /// Gets current conditions using helper method.
    /// </summary>
    public async Task ShowCurrentConditionsAsync()
    {
        if(City == null)
            City = await SetCityAsync();

        var currentConditions = await GetWeatherHelper.GetCurrentConditions(City.Key, Language);

        Console.WriteLine($"\n Wybrałeś {City.LocalizedName}, {City.AdministrativeArea.LocalizedName}, {City.Country.LocalizedName}. Jest {currentConditions.LocalObservationDateTime:g} \n " +
            $"{currentConditions.WeatherText}, {currentConditions.Temperature.Metric.Value}°{currentConditions.Temperature.Metric.Unit}" +
            $"({currentConditions.Temperature.Imperial.Value}°{currentConditions.Temperature.Imperial.Unit})" + Environment.NewLine);
    }

    /// <summary>
    /// Displays forecast for either next 12 hours or the next five days.
    /// </summary>
    public async Task ShowLatestForecastAsync()
    {
        if(City == null)
            City = await SetCityAsync();

        Console.WriteLine($"Prognoza dla: {City.LocalizedName}. Wybierz preferowany rodzaj prognozy:" + Environment.NewLine +
                            "1. Prognoza godzinowa (12 godzin)" + Environment.NewLine +
                            "2. Prognoza dniowa (5 dni)" + Environment.NewLine);

        Console.Write("Wpisz numer i potwierdź klawiszem ENTER: ");
            int.TryParse(Console.ReadLine(), out int selectedNumber);
        
        if(selectedNumber == 1)
        {
            var forecast = await GetWeatherHelper.Get12hrsForecast(City.Key, Language);

            foreach(var f in forecast)
            {
                Console.WriteLine($"{City.LocalizedName}, {f.DateTime.Hour:D2}:{f.DateTime.Minute:D2}" + Environment.NewLine +
                                    $"{f.IconPhrase}, {f.Temperature.Value}°{f.Temperature.Unit}.");
                if(f.HasPrecipitation)
                {
                    Console.WriteLine($"{f.PrecipitationType}, {f.PrecipitationIntensity}.");
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
        else if(selectedNumber == 2)
        {
            var forecast = await GetWeatherHelper.Get5DaysForecast(City.Key, Language);

            Console.WriteLine($"{City.LocalizedName}, {forecast.Headline.EffectiveDate:ddd d MMM yyyy}" + Environment.NewLine +
                                        $"{forecast.Headline.Text}" + Environment.NewLine);
            foreach(var f in forecast.DailyForecasts)
            {
                Console.WriteLine($"{f.Date:dddd}:" + Environment.NewLine +
                                    $"W ciągu dnia {f.Day.IconPhrase}, a w nocy {f.Night.IconPhrase}. Temperatura od {f.Temperature.Minimum.Value}°C do {f.Temperature.Maximum.Value}°C."
                                    + Environment.NewLine);
            }                                        
        }
        else  Console.WriteLine("Nie wybrano żadnej opcji - powrót do menu głównego" + Environment.NewLine);

        Console.WriteLine("Naciśnij dowolny klawisz, by wrócić do menu.");
        Console.ReadKey();
        System.Console.WriteLine(Environment.NewLine);
    }

    #endregion
}
public enum Options
{    
    SetCity,
    GetCurrentConditions,
    GetForecast,
    Quit
}