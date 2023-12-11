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
using static ObjCRuntime.Dlfcn;
using static System.Net.WebRequestMethods;

namespace WeatherNotification.Weather_MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class WeatherViewModel
    {

        protected static Services.WeatherService WeatherService => Services.WeatherService.Instance;

        private WeatherAppData _weatherAppData { get; set; } //Don't use this directly in the XAML, this should stay private, see notes below.

        //Add a public variable here for everything that needs to be displayed on the screen. Populate each of them inside the InitializeWeather method. That way you don't need to use WeatherAppData.Class.Class.... in your XAML. In your ZAMK, bind all the controls to the public variables.
        public string PlaceName { get; set; }
        public DateTime Date => DateTime.Now;
        public string WindSpeed { get; set; }
        public string WeatherCode { get; set; }
        public string WeatherDescription { get; set; }

        public WeatherViewModel()
        {
        }
        public ICommand SearchCommand =>
            new Command(async (searchText) =>
            {
                await InitializeWeather(searchText.ToString());
            });

        private async Task InitializeWeather(string address)
        {
            PlaceName = address;
            _weatherAppData = await WeatherService.GetWeatherAsync(address);
            WindSpeed = _weatherAppData.current.wind_speed_10m.ToString();
            //Assign all of the pubic variables here. See notes above.

            var (description, animation) = GetWeatherDescriptionAndAnimation(_weatherAppData.current.weather_code);

            WeatherDescription = description;

            switch (animation)
            {
                case "clear":
                    //Show clear animation.
                    break;
                //etc...
            }
        }


        public (string description, string animation) GetWeatherDescriptionAndAnimation(int code)
        {
            string description = "";
            string animation = "";
            switch (code)
            {
                case 0:
                    description = "Clear sky";
                    animation = "clear";
                    break;
                case 1:
                case 2:
                case 3:
                    description = "Mainly clear, partly cloudy, and overcast";
                    animation = "partcloudy";
                    break;
                case 45:
                case 48:
                    description = "Fog and depositing rime fog";
                    animation = "foggy";
                    break;
                case 51:
                case 53:
                case 55:
                    description = "Drizzle: Light, moderate, and dense intensity";
                    animation = "rain";
                    break;
                case 56:
                case 57:
                    description = "Freezing Drizzle: Light and dense intensity";
                    animation = "rain";
                    break;
                case 61:
                case 63:
                case 65:
                    description = "Rain: Slight, moderate and heavy intensity";
                    animation = "rain";
                    break;
                case 66:
                case 67:
                    description = "Freezing Rain: Light and heavy intensity";
                    animation = "rain";
                    break;
                case 71:
                case 73:
                case 75:
                    description = "Snow fall: Slight, moderate, and heavy intensity";
                    animation = "snow";
                    break;
                case 77:
                    description = "Snow grains";
                    animation = "snow";
                    break;
                case 80:
                case 81:
                case 82:
                    description = "Rain showers: Slight, moderate, and violent";
                    animation = "rain";
                    break;
                case 85:
                case 86:
                    description = "Snow showers slight and heavy";
                    animation = "snow";
                    break;
                case 95:
                    description = "Thunderstorm: Slight or moderate";
                    animation = "thunder";
                    break;
                case 96:
                case 99:
                    description = "Thunderstorm with slight and heavy hail";
                    animation = "thunder";
                    break;
                default:
                    description = "Unknown weather code";
                    animation = "unknown";
                    break;
            }
            return (description, animation);
        }
    }
}
