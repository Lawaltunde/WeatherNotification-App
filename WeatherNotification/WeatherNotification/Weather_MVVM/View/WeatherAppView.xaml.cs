using WeatherNotification.Weather_MVVM.ViewModels;

namespace WeatherNotification.Weather_MVVM.View;

public partial class WeatherAppView : ContentPage
{
	public WeatherAppView()
	{
		InitializeComponent();
		BindingContext = new WeatherViewModel();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		//To do
    }
}