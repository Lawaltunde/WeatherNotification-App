using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherNotification.Weather_MVVM.Models;

namespace WeatherNotification.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        private static WeatherService _instance;
        public static WeatherService Instance => _instance ??= new WeatherService();


        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherAppData> GetWeatherAsync(string address)
        {
            var location = await GetLocationAsync(address);
            return await GetWeatherAsync(location);
        }

            public async Task<WeatherAppData> GetWeatherAsync(Location location)
        {
            try
            {
                if (location == null)
                    return null;

                var url =
                    $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&current=temperature_2m,weather_code,wind_speed_10m&daily=weather_code,temperature_2m_max,temperature_2m_min&timezone=America%2FChicago";
                var response =
                     await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var data = await JsonSerializer
                         .DeserializeAsync<WeatherAppData>(responseStream);

                    return data;
                }
            }
            catch
            {
                //Failed to get data.
            }
            return null;
        }

        private async Task<Location> GetLocationAsync(string address)
        {
            try
            {
                if (address == null)
                    return null;

                IEnumerable<Location> locations = await Geocoding
                     .Default.GetLocationsAsync(address);

                Location location = locations?.FirstOrDefault();

                if (location != null)
                    Console
                         .WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                return location;
            }
            catch
            {

            }
            return null;
        }
    }

}
