using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherNotification.Weather_MVVM.Models;
using static System.Net.WebRequestMethods;

namespace WeatherNotification.Weather_MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class WeatherViewModel
    {

        protected static Services.WeatherService WeatherService => Services.WeatherService.Instance;

        public WeatherAppData WeatherAppData { get; set; }
        private readonly HttpClient _httpClient;
        public string PlaceName { get; set; }
        public DateTime GetDate { get; set; } = DateTime.Now;

        public WeatherViewModel() { 
            _httpClient = new HttpClient();
        }
        public ICommand SearchCommand =>
            new Command(async (searchText) =>
            {
                PlaceName = searchText.ToString();
                WeatherAppData = await WeatherService.GetWeatherAsync(searchText.ToString());
            });



    }
}
