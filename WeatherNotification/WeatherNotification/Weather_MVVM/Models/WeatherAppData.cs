using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherNotification.Weather_MVVM.Models
{
   //Getting a daily weather forecast from open-meteo
    public class Daily_Units
    {
        public string time { get; set; }
        public string weather_code { get; set; }
        public string temperature_2m_max { get; set; }
        public string temperature_2m_min { get; set; }
    }

    //Getting current time, weather_code, min and max temperature from open-meteo

    public class Daily
    {
        public string[] time { get; set; }
        public int[] weather_code { get; set; }
        public float[] temperature_2m_max { get; set; }
        public float[] temperature_2m_min { get; set; }
    }

}
