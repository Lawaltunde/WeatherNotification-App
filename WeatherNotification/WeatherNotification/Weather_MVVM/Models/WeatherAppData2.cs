using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherNotification.Weather_MVVM.Models
{
    ////Getting a current time, weather_code, wind_speed in km/hr and temperature from open-meteo
    public class Current_Units
    {
        public string time { get; set; }
        public string interval { get; set; }
        public string temperature_2m { get; set; }
        public string weather_code { get; set; }
        public string wind_speed_10m { get; set; }
    }
}
