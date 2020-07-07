using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WeatherForecast.Lib.Helpers
{
    public static class StringHelpers
    {
        /// <summary>
        /// Converts polish signs in the city name into UTF-8 bytes representation.
        /// </summary>
        /// <param name="input">Polish city name</param>
        /// <returns></returns>
        public static string ConvertPolishSigns(this string input)
        {
            return HttpUtility.UrlEncode(input);
        }

        
    }
}
