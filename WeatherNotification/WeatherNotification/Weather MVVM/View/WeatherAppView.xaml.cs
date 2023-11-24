using WeatherNotification.Weather_MVVM.ViewModels;

namespace WeatherNotification.Weather_MVVM.View;

public partial class WeatherAppView : ContentPage
{
	public WeatherAppView()
	{
		InitializeComponent();
		BindingContext = new WeatherAppViewModels();
	}
}