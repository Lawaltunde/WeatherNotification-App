using WeatherNotificationApp.WeatherApp_MVVM.ViewModels;

namespace WeatherNotificationApp.WeatherApp_MVVM.View;

public partial class WeatherAppView : ContentPage
{
	public WeatherAppView()
	{
        InitializeComponent();
        BindingContext = new WeatherAppViewModel();
    }
}