using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Excel.Converters
{
    /// <summary>
    /// Конвертор для конвертация Teacher в соотвутсвующую строку Инциалов.
    /// </summary>
    public class TeacherInitialsExcelConverter
    {
        /// <inheritdoc/>
        public object Convert(object value)
        {
            Teacher teacher = (Teacher)value;
            if (teacher != null)
            {
                return $"{teacher.LastName} {teacher.FirstName[0]}.{teacher.MiddleName[0]}.";
            }

            return string.Empty;
        }

        /// <inheritdoc/>
        public object ConvertBack(object value)
        {
            throw new NotImplementedException();
        }
    }
}
