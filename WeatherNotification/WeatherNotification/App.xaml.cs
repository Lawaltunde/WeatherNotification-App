using WeatherNotification.Weather_MVVM.View;
using WeatherNotification.Weather_MVVM.ViewModels;

namespace WeatherNotification
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
