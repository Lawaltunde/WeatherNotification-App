using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace WeatherNotificationApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureEssentials(essentials =>
                {
                    essentials.UseMapServiceToken("g8N9nCOT71f7Uv9fdsP5~MzswWLsjP4Re4wljtBTz3g~AiPN3Cf-qVA3DgO9DhzobomFiYBvwkqfQBxAw4mkUQe91VTJ023Loq9_6y0FzDa9");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
