using System;
using System.Globalization;
using System.Windows.Data;
using Data.Models;

namespace Infrastructure.Converters
{
    /// <summary>
    /// Конвертор для конвертация Teacher в соотвутсвующую строку Инциалов.
    /// </summary>
    [ValueConversion(typeof(Teacher), typeof(string))]
    public class TeacherInitialsConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Teacher teacher = (Teacher)value;
            if (teacher != null)
            {
                return $"{teacher.LastName} {teacher.FirstName[0]}.{teacher.MiddleName[0]}.";
            }

            return string.Empty;
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
