using Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace Infrastructure.Converters
{
    /// <summary>
    /// Конвертор для конвертация коллекции Group в соотвутсвующую строку с их названиями.
    /// </summary>
    public class GroupsNamesToInfoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var groups = (List<Group>)value;

            string names = string.Empty;

            if (groups.Count == 1)
                return groups[0].Name;

            if (groups != null)
            {
                foreach(var group in groups)
                {
                    names = names + $"{group.Name},";
                }
            }
            names.TrimEnd('.');
            return names;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
