using System;
using Xunit;
using WeatherForecast.Lib.Helpers;

namespace ConvertPolishSignsTest
{
    public class UnitTest1
    {
        [Fact]
        public void ChangesPolishSignsToHexBytes()
        {
            //arrange
            string input = "Łódź";

            //act
            string output = input.ConvertPolishSigns();

            //assert
            Assert.Equal("%C5%81%C3%83d%C5%BC", output);
        }
    }
}
