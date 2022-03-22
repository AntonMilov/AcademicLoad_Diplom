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

       /// <summary>
       /// Конвертация должности в номер колонки.
       /// </summary>
       /// <param name="value">Значение</param>
       /// <returns>Номер колонки</returns>
        public int ConvertToColumn(object value)
        {
            AcademicTitle academicTitle = (AcademicTitle)value;

            switch (academicTitle)
            {
                case AcademicTitle.Dekan:
                    return 3;

                case AcademicTitle.HeadDepartment:
                    return 4 ;

                case AcademicTitle.Professor:
                    return 5 ;

                case AcademicTitle.Docent:
                    return 6 ;

                case AcademicTitle.SeniorLecturer:
                    return 7;

                case AcademicTitle.Lecturer:
                    return 8;

                case AcademicTitle.Assistant:
                    return 9;

                default:
                    return 0;
            }
        }

        /// <inheritdoc/>
        public object ConvertBack(object value)
        {
            throw new NotImplementedException();
        }
    }
}
