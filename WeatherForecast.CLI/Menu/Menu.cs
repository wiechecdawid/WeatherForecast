using System;
/// <summary>
/// A singleton class responsible for displaying menu.
/// </summary>
public sealed class Menu
{
    private static Menu _instance = null;
    private static readonly object _lock = new object();
    private int _choice = -1;
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

    public void Navigate()
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
                            break;
                        case Options.GetCurrentConditions:
                            break;
                        case Options.GetForecast:
                            break;
                        case Options.Quit:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
    }
}
public enum Options
{    
    SetCity,
    GetCurrentConditions,
    GetForecast,
    Quit
}