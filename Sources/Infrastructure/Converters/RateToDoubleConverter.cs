using Data.Enums;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Infrastructure.Converters
{
    /// <summary>
    /// Ковнертер для преобразования Rate в значение Double.
    /// </summary>
    public class RateToDoubleConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double rate = (double)value;

            switch (rate)
            {
                case 0.25:
                    return "25";

                case 0.50:
                    return "50";

                case 0.75:
                    return "75";

                case 100:
                    return "100";

                case 0.00:
                    return "Почасовая";

                default:
                    return "";
            }
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case Rate.Rate25:
                    return 0.25;

                case Rate.Rate50:
                    return 0.50;

                case Rate.Rate75:
                    return 0.75;

                case Rate.Rate100:
                    return 0.100;

                case Rate.RateHourly:
                    return 0.00;

                default:
                    return 0.00;
            }
        }
    }
}
