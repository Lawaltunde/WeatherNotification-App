using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherNotification.Weather_MVVM.Models
{
    public class Current
    {
        public string time { get; set; }
        public int interval { get; set; }
        public float temperature_2m { get; set; }
        public int weather_code { get; set; }
        public float wind_speed_10m { get; set; }
    }
}
