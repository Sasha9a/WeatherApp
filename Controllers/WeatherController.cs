using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Weather.Models;

namespace Weather.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private static readonly string[] Direction = new[]
        {
            "С", "СЗ", "З", "ЮЗ", "Ю", "ЮВ", "В", "СВ"
        };
        private static readonly string[] Precipitation = new[]
        {
            "Солнечно", "Облачно", "Небольшой дождь", "Сильный дождь", "Гроза"
        };

        [HttpGet]
        public ActionResult<IEnumerable<DataWeatherModel>> Get()
        {
            List<DataWeatherModel> data = new List<DataWeatherModel>();
            Random rand = new Random();

            for (int i = 0; i != 10; i++)
            {
                DataWeatherModel dataWeather = new DataWeatherModel();
                int MinTemp = rand.Next(20, 30);

                dataWeather.Date = DateTime.Now.AddDays(i).ToShortDateString();
                dataWeather.Temperature = String.Format("+{0} (+{1})", rand.Next(MinTemp, 30), MinTemp);
                dataWeather.Pressure = String.Format("{0} мм рт.ст.", rand.Next(730, 760));
                dataWeather.Humidity = String.Format("{0}%", rand.Next(0, 100));
                dataWeather.Wind = String.Format("{0} м/с, {1}", rand.Next(1, 30), Direction[rand.Next(Direction.Length)]);
                dataWeather.Precipitation = Precipitation[rand.Next(Precipitation.Length)];

                data.Add(dataWeather);
            }
            return data;
        }
    }
}
