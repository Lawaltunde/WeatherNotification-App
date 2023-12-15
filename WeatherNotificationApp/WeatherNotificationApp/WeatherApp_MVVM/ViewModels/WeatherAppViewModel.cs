using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherNotificationApp.WeatherApp_MVVM.Models;

namespace WeatherNotificationApp.WeatherApp_MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class WeatherAppViewModel
    {
        public WeatherAppData _weatherData { get; set; }
        public string PlaceName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        private HttpClient _httpClient;

        public WeatherAppViewModel() {
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
            var response =
                await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer
                         .DeserializeAsync<WeatherAppData>(responseStream);
                    _weatherData = data;

                    //The below loop goes through the properties of daily class
                    for (int i = 0; i < _weatherData.daily.time.Length; i++)
                    {
                        //there are bugs to fix, animation is not getting updated yet
                        var daily2 = new Daily2
                        {
                            time = _weatherData.daily.time[i],
                            temperature_2m_max = _weatherData.daily.temperature_2m_max[i],
                            temperature_2m_min = _weatherData.daily.temperature_2m_min[i],
                            weather_code = _weatherData.daily.weather_code[i]
                        };
                        //adding the instance to daily2 list
                        _weatherData.daily2.Add(daily2);
                    }
                }
            }
        }
            private async Task<Location> GetCoordinatesAsync(string address)
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

