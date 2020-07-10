/// <summary>
/// A singleton class responsible for displaying menu.
/// </summary>
public sealed class Menu
{
    private static Menu _instance = null;
    private static readonly object _lock = new object();
    private int _choice;
    Menu(){}
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
    public string Language { get; set; }
}
public enum Options
{
    ChangeLanguage,
    GetCurrentConditions,
    GetForecast,
    Quit
}