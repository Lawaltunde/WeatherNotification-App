using WeatherNotificationApp.WeatherApp_MVVM.View;

namespace WeatherNotificationApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new WeatherAppView();
        }
    }
}
