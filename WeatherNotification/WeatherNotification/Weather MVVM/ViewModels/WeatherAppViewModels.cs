using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherNotification.Weather_MVVM.Models;

namespace WeatherNotification.Weather_MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class WeatherAppViewModels
    {
        public WeatherData _weatherData { get; set; }
        public string PlaceName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        private HttpClient _httpClient;

        public WeatherAppViewModels() {
            _httpClient = new HttpClient();
        }
        public ICommand SearchCommand =>
               new Command(async (searchText) =>
               {
                   PlaceName = searchText.ToString();
                   var location =
                        await GetCoordinatesAsync(searchText.ToString());
                   await GetWeather(location);
               });

        private async Task GetWeather(Location location)
        {
            var url =
                $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&current=temperature_2m,weather_code,wind_speed_10m&hourly=weather_code&daily=weather_code,temperature_2m_max,temperature_2m_min&timezone=America%2FChicago";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<WeatherData>(responseStream);
                    _weatherData = data;
                    Console.WriteLine(_weatherData.current.temperature_2m);

                }
            }
        }

        private static async Task<Location> GetCoordinatesAsync(string address)
        {
            IEnumerable<Location> locations = await Geocoding
                    .Default.GetLocationsAsync(address);

            Location location = locations?.FirstOrDefault();

            if (location != null)
                Console
                        .WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
            return location;
        }
    }
}
