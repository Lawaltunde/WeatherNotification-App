﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherNotificationApp.WeatherApp_MVVM.Models
{
  
    public class WeatherAppData
    {//parent class
        public float latitude { get; set; }
        public float longitude { get; set; }
        public float generationtime_ms { get; set; }
        public int utc_offset_seconds { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public float elevation { get; set; }
        public Current_Units current_units { get; set; }
        public Current current { get; set; }
        public Hourly_Units hourly_units { get; set; }
        public Hourly hourly { get; set; }
        public Daily_Units daily_units { get; set; }
        public Daily daily { get; set; }
        public ObservableCollection<Daily2> daily2 {  get; set; } = 
            new ObservableCollection<Daily2>();
    }

    public class Current_Units
    {
        public string time { get; set; }
        public string interval { get; set; }
        public string temperature_2m { get; set; }
        public string weather_code { get; set; }
        public string wind_speed_10m { get; set; }
    }

    public class Current
    {
        public string time { get; set; }
        public int interval { get; set; }
        public float temperature_2m { get; set; }
        public int weather_code { get; set; }
        public float wind_speed_10m { get; set; }
    }

    public class Hourly_Units
    {
        public string time { get; set; }
        public string weather_code { get; set; }
    }

    public class Hourly
    {
        public string[] time { get; set; }
        public int[] weather_code { get; set; }
    }

    public class Daily_Units
    {
        public string time { get; set; }
        public string weather_code { get; set; }
        public string temperature_2m_max { get; set; }
        public string temperature_2m_min { get; set; }
    }

    public class Daily
    {
        public string[] time { get; set; }
        public int[] weather_code { get; set; }
        public float[] temperature_2m_max { get; set; }
        public float[] temperature_2m_min { get; set; }
    }


    //Daily2 has same properties as Daily class but storing a single weatherforecast data because we want it instant to have it own information
    public class Daily2
    {
        public string time { get; set; }
        public float weather_code { get; set; }
        public float temperature_2m_max { get; set; }
        public float temperature_2m_min { get; set; }
    }

}
