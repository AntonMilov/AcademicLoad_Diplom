using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Excel.Converters
{
    /// <summary>
    /// Конвертор для конвертация AcademicTitle в соотвутсвующую строку названия должности.
    /// </summary>
    public class AcademicTitleToNameExcelConverter
    {
        /// <summary>
        /// Конвертация.
        /// </summary>
        public object Convert(object value)
        {
            AcademicTitle academicTitle = (AcademicTitle)value;

            switch (academicTitle)
            {
                case AcademicTitle.Dekan:
                    return "Декан";

                case AcademicTitle.HeadDepartment:
                    return "Зав. кафедрой";

                case AcademicTitle.Professor:
                    return "Профессор";

                case AcademicTitle.Docent:
                    return "Доцент";

                case AcademicTitle.SeniorLecturer:
                    return "Старший преподаватель";

                case AcademicTitle.Lecturer:
                    return "Преподаватель";

                case AcademicTitle.Assistant:
                    return "Ассистент";

                default:
                    return "";
            }
        }

        /// <inheritdoc/>
        public object ConvertBack(object value)
        {
            throw new NotImplementedException();
        }
    }
}
