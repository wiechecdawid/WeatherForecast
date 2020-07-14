using System.Threading.Tasks;

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
