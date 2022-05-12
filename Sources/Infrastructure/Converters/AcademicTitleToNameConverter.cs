using Data.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Infrastructure.Converters
{
    /// <summary>
    /// Конвертор для конвертация AcademicTitle в соотвутсвующую строку названия должности.
    /// </summary>
    [ValueConversion(typeof(AcademicTitle), typeof(string))]
    public class AcademicTitleToNameConverter : IValueConverter
    {
        /// <summary>
        /// Конвертация.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            AcademicTitle academicTitle = (AcademicTitle)value;

            switch (academicTitle)
            {
                case AcademicTitle.Dekan:
                    return Properties.Resources.Dekan;

                case AcademicTitle.HeadDepartment:
                    return Properties.Resources.HeadDepartment;

                case AcademicTitle.Professor:
                    return Properties.Resources.Professor;

                case AcademicTitle.Docent:
                    return Properties.Resources.Docent;

                case AcademicTitle.SeniorLecturer:
                    return Properties.Resources.SeniorLecturer;

                case AcademicTitle.Lecturer:
                    return Properties.Resources.Lecturer;

                case AcademicTitle.Assistant:
                    return Properties.Resources.Assistant;

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
