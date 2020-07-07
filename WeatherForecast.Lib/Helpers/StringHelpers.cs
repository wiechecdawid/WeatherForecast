using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
            string pattern = @"[ąćęłńóśźżĄĆĘŁŃÓŚŹŻ]";
            MatchEvaluator eval = new MatchEvaluator(Converter);
            
            return Regex.Replace(input, pattern, eval);
        }

        public static string Converter(Match match)
        {
            int arraySize = match.Value.Length;
            string[] letters = new string[arraySize];
            for(int i = 0; i < arraySize; i++)
            {
                switch(match.Value[i])
                {
                    case 'ą':
                        letters[i] = "%C4%85";
                        break;
                    case 'ć':
                        letters[i] = "%C4%87";
                        break;
                    case 'ę':
                        letters[i] = "%C4%99";
                        break;
                    case 'ł':
                        letters[i] = "%C5%82";
                        break;
                    case 'ń':
                        letters[i] = "%C5%84";
                        break;
                    case 'ó':
                        letters[i] = "%C3%83";
                        break;
                    case 'ś':
                        letters[i] = "%C5%9B";
                        break;
                    case 'ź':
                        letters[i] = "%C5%BA";
                        break;
                    case 'ż':
                        letters[i] = "%C5%BC";
                        break;

                    case 'Ą':
                        letters[i] = "%C4%84";
                        break;
                    case 'Ć':
                        letters[i] = "%C4%86";
                        break;
                    case 'Ę':
                        letters[i] = "%C4%98";
                        break;
                    case 'Ł':
                        letters[i] = "%C5%81";
                        break;
                    case 'Ń':
                        letters[i] = "%C5%83";
                        break;
                    case 'Ó':
                        letters[i] = "%C3%93";
                        break;
                    case 'Ś':
                        letters[i] = "%C5%9A";
                        break;
                    case 'Ź':
                        letters[i] = "%C5%B9";
                        break;
                    case 'Ż':
                        letters[i] = "%C5%BB";
                        break;
                }
            }
            return letters.ToString();
        }
    }
}
