using System;

public class DailyForecast
{
    public DateTime Date { get; set; }
    public int EpochDate { get; set; }
    public DailyTemp Temperature { get; set; }
    public TimeOfDay Day { get; set; }
    public TimeOfDay Night { get; set; }
    public string[] Sources { get; set; }
    public string MobileLink { get; set; }
    public string Link { get; set; }
}