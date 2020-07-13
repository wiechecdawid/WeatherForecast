using System;
using WeatherForecast.Lib.Models;

public class ForecastedConditions
{
    public DateTime DateTime { get; set; }
    public int EpochDateTime { get; set; }
    public int WeatherIcon { get; set; }
    public string IconPhrase { get; set; }
    public bool HasPrecipitation { get; set; }
    public string PrecipitationType { get; set; }
    public string PrecipitationIntensity { get; set; }
    public bool IsDayLight { get; set; }
    public TempUnit Temperature { get; set; }
}