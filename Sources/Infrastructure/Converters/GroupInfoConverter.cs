using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Data.Models;

namespace Infrastructure.Converters
{
    /// <summary>
    /// Конвертор для конвертация Group в соотвутсвующую строку Информации.
    /// </summary>
    [ValueConversion(typeof(Group), typeof(string))]
    public class GroupInfoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Group group = (Group)value;
            if (group != null)
            {
                return $"{group.Name.ToUpper()} {group.Students} студентов";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
