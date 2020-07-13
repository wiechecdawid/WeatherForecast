using System;

public class DailyForecast
{
    public DateTime Date { get; set; }
    public int EpochDate { get; set; }
    public DailyTemp Temperature { get; set; }
    public bool HasPrecipitation { get; set; }
    public string PrecipitationType { get; set; }
    public string PrecipitationIntensity { get; set; }
    public string[] Sources { get; set; }
    public string MobileLink { get; set; }
    public string Link { get; set; }
}