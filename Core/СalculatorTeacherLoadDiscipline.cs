﻿

using Data.Models;

namespace Core
{
    /// <summary>
    /// Класс для рассчета нагрузки.
    /// </summary>
    public class СalculatorTeacherLoadDiscipline
    {
        /// <summary>
        /// Расчет назначения для основного лектора.
        /// </summary>
        /// <param name="teacherLoadDiscipline">.</param>
        /// <param name="calculationSheetDiscipline">.</param>
        public void CalculateForMainLecture(TeacherLoadDiscipline teacherLoadDiscipline, CalculationSheetDiscipline calculationSheetDiscipline)
        {
            teacherLoadDiscipline.Semester = calculationSheetDiscipline.Semester;

            teacherLoadDiscipline.HoursLecture = calculationSheetDiscipline.HoursLecture;
            teacherLoadDiscipline.HoursLaboratoryWork = calculationSheetDiscipline.HoursLaboratoryWork;
            teacherLoadDiscipline.HoursPracticum = calculationSheetDiscipline.HoursPracticum;
            teacherLoadDiscipline.HoursKpKr = calculationSheetDiscipline.HoursKpKr;
            teacherLoadDiscipline.HoursСontrolWork = calculationSheetDiscipline.HoursСontrolWork;
            teacherLoadDiscipline.HoursExam = calculationSheetDiscipline.HoursExam;
            teacherLoadDiscipline.HoursTest = calculationSheetDiscipline.HoursTest;
            teacherLoadDiscipline.HoursConsultation = calculationSheetDiscipline.HoursConsultation;
        }

        /// <summary>
        /// Расчет назначения для дополнительного лектора.
        /// </summary>
        /// <param name="teacherLoadDiscipline">.</param>
        /// <param name="calculationSheetDiscipline">.</param>
        public void CalculateForAdditionalLecture(TeacherLoadDiscipline teacherLoadDiscipline, CalculationSheetDiscipline calculationSheetDiscipline)
        {
            teacherLoadDiscipline.Semester = calculationSheetDiscipline.Semester;

            teacherLoadDiscipline.HoursLecture = calculationSheetDiscipline.HoursLecture;
            teacherLoadDiscipline.HoursLaboratoryWork = calculationSheetDiscipline.HoursLaboratoryWork;
            teacherLoadDiscipline.HoursPracticum = calculationSheetDiscipline.HoursPracticum;
            teacherLoadDiscipline.HoursKpKr = calculationSheetDiscipline.HoursKpKr;
            teacherLoadDiscipline.HoursСontrolWork = calculationSheetDiscipline.HoursСontrolWork;
         
            teacherLoadDiscipline.HoursTest = calculationSheetDiscipline.HoursTest;
            teacherLoadDiscipline.HoursConsultation = calculationSheetDiscipline.HoursConsultation;
        }

        /// <summary>
        /// Расчет назначения для преподавателя, который не является лектором.
        /// </summary>
        /// <param name="teacherLoadDiscipline">.</param>
        /// <param name="calculationSheetDiscipline">.</param>
        public void CalculateForNotLecture(TeacherLoadDiscipline teacherLoadDiscipline, CalculationSheetDiscipline calculationSheetDiscipline)
        {
            teacherLoadDiscipline.Semester = calculationSheetDiscipline.Semester;

    
            teacherLoadDiscipline.HoursLaboratoryWork = calculationSheetDiscipline.HoursLaboratoryWork;
            teacherLoadDiscipline.HoursPracticum = calculationSheetDiscipline.HoursPracticum;
            teacherLoadDiscipline.HoursKpKr = calculationSheetDiscipline.HoursKpKr;
            teacherLoadDiscipline.HoursСontrolWork = calculationSheetDiscipline.HoursСontrolWork;

            teacherLoadDiscipline.HoursTest = calculationSheetDiscipline.HoursTest;
            teacherLoadDiscipline.HoursConsultation = calculationSheetDiscipline.HoursConsultation;
        }
    }
}
