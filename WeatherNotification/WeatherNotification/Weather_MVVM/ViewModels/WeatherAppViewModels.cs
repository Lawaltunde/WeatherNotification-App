using PropertyChanged;
using System;
using System.Collections.Generic;
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
        public WeatherAppData WeatherAppData { get; set; }
        public string PlaceName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        private HttpClient client;

        public WeatherAppViewModels()
        {
            client = new HttpClient();
            
        }
        public ICommand SearchCommand =>
            new Command(async (searchText) =>
            {
                PlaceName = searchText.ToString();
                var location = new Location
                {
                    Latitude = 43.4668, //  predefined latitude
                    Longitude = -80.5164 // predefined longitude
                };
                 
                await GetWeather(location);
            });

        private async Task GetWeather(Location location)
        {
            var url = $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&current=temperature_2m,weather_code,wind_speed_10m&daily=weather_code,temperature_2m_max,temperature_2m_min&timezone=America%2FChicago";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = JsonSerializer.Deserialize<WeatherAppData>(responseStream);
                    WeatherAppData = data;
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
            else
            {
                Console.WriteLine($"No location found for address: {address}");
            }
            return location;
        }
    }
}
