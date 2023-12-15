using WeatherNotificationApp.WeatherApp_MVVM.ViewModels;

namespace WeatherNotificationApp.WeatherApp_MVVM.View;

public partial class WeatherAppView : ContentPage
{
    public WeatherAppView()
    {
        InitializeComponent();
        BindingContext = new WeatherAppViewModel();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //This event handler is added just for our button not to be functionless pending the time 
        DateTime currentDate = DateTime.Now;

        // Display the current date in an alert
        DisplayAlert("Current Date", $"Today's date is {currentDate.ToShortDateString()}", "OK");
    }
}