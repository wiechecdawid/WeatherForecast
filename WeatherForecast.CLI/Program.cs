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
            var menu = Menu.Instance;

            await menu.NavigateAsync();
        }       
    }
}
