
using Data.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Infrastructure.Converters
{
    /// <summary>
    /// Конвертор для конвертация Rate в соотвутсвуещие название или значение Double.
    /// </summary>
    public class RateConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Rate rate = (Rate)value;

            switch (rate)
            {
                case Rate.Rate25:
                    return "0,25";

                case Rate.Rate50:
                    return "0,5";

                case Rate.Rate75:
                    return "0,75";

                case Rate.Rate100:
                    return "1";

                case Rate.RateHourly:
                    return "Почасовая";

                default:
                    return "";
            }
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
