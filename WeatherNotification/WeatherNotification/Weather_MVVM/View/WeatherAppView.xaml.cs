//using Intents;
using WeatherNotification.Weather_MVVM.Models;
using WeatherNotification.Weather_MVVM.ViewModels;

namespace WeatherNotification.Weather_MVVM.View;

public partial class WeatherAppView : ContentPage
{
	public WeatherAppView()
	{
		InitializeComponent();
		BindingContext = new WeatherViewModel();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        TimePicker timePicker;

        timePicker = new TimePicker
        {
            Format = "HH:mm",
            Time = DateTime.Now.TimeOfDay
        };

        TimeSpan chosenTime = timePicker.Time;
        DateTime chosenDateTime = DateTime.Now.Date + chosenTime;

        await DisplayAlert("Choosen Time", $"Choosen Time: {chosenDateTime.ToString("HH:mm:ss")}", "Ok");

        

    }
}