using SkiaSharp.Extended.UI.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherNotification.ServiceData
{
    public class CodeToLottieConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var code = value;
            var lottienImageSource = new SKFileLottieImageSource();

            switch (code)
            {
                case 0:
                    lottienImageSource.File = "Sunny.json";
                    return lottienImageSource;
                case 1:
                    lottienImageSource.File = "Sunny.json";
                    return lottienImageSource;

                case 2:
                    lottienImageSource.File = "foggy.json";
                    return lottienImageSource;

                case 3:
                    lottienImageSource.File = "foggy.json";
                    return lottienImageSource;

                case 45:
                    lottienImageSource.File = "foggy.json";
                    return lottienImageSource;

                case 48:
                    lottienImageSource.File = "foggy.json";
                    return lottienImageSource;

                case 51:
                    lottienImageSource.File = "Partly-shower.json";
                    return lottienImageSource;

                case 53:
                    lottienImageSource.File = "Partly-shower.json";
                    return lottienImageSource;

                case 55:
                    lottienImageSource.File = "Partly-shower.json";
                    return lottienImageSource;

                case 56:
                    lottienImageSource.File = "Partly-shower.json";
                    return lottienImageSource;

                case 57:
                    lottienImageSource.File = "Partly-shower.json";
                    return lottienImageSource;

                case 61:
                    lottienImageSource.File = "stormshowersday.json";
                    return lottienImageSource;

                case 63:
                    lottienImageSource.File = "stormshowersday.json";
                    return lottienImageSource;

                case 65:
                    lottienImageSource.File = "stormshowersday.json";
                    return lottienImageSource;

                case 66:
                    lottienImageSource.File = "snow.json";
                    return lottienImageSource;

                case 67:
                    lottienImageSource.File = "snow.json";
                    return lottienImageSource;

                case 71:
                    lottienImageSource.File = "snow.json";
                    return lottienImageSource;

                case 73:
                    lottienImageSource.File = "snow.json";
                    return lottienImageSource;

                case 75:
                    lottienImageSource.File = "snow.json";
                    return lottienImageSource;

                case 77:
                    lottienImageSource.File = "snow.json";
                    return lottienImageSource;

                case 80:
                    lottienImageSource.File = "Storm.json";
                    return lottienImageSource;

                case 81:
                    lottienImageSource.File = "Storm.json";
                    return lottienImageSource;

                case 82:
                    lottienImageSource.File = "Storm.json";
                    return lottienImageSource;

                case 85:
                    lottienImageSource.File = "Storm.json";
                    return lottienImageSource;

                case 86:
                    lottienImageSource.File = "Storm.json";
                    return lottienImageSource;

                case 95:
                    lottienImageSource.File = "Storm.json";
                    return lottienImageSource;

                case 96:
                case 99:
                    lottienImageSource.File = "Storm.json";
                    return lottienImageSource;

                default: return "Unknown";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
