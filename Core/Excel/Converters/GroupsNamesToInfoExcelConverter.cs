using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Excel.Converters
{
    /// <summary>
    /// Конвертор для конвертация коллекции Group в соотвутсвующую строку с их названиями.
    /// </summary>
    public class GroupsNamesToInfoExcelConverter
    {
        public object Convert(object value)
        {
            var groups = (List<Group>)value;

            string names = string.Empty;

            if (groups.Count == 1)
                return groups[0].Name;

            if (groups != null)
            {
                foreach (var group in groups)
                {
                    names = names + $"{group.Name},";
                }
            }
            names.TrimEnd('.');
            return names;
        }

        public object ConvertBack(object value)
        {
            throw new NotImplementedException();
        }
    }
}
