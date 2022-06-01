

using Data.Enums;
using Data.Models;
using System.Collections.Generic;
using System.Linq;

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
            teacherLoadDiscipline.HoursLaboratoryWork = calculationSheetDiscipline.CountLaboratoryWork;
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
            teacherLoadDiscipline.HoursLaboratoryWork = calculationSheetDiscipline.CountLaboratoryWork;
            teacherLoadDiscipline.HoursPracticum = calculationSheetDiscipline.HoursPracticum;
            teacherLoadDiscipline.HoursKpKr = calculationSheetDiscipline.HoursKpKr;
            teacherLoadDiscipline.HoursСontrolWork = calculationSheetDiscipline.HoursСontrolWork;

            teacherLoadDiscipline.HoursTest = calculationSheetDiscipline.HoursTest;
        }

        /// <summary>
        /// Расчет назначения для преподавателя, который не является лектором.
        /// </summary>
        /// <param name="teacherLoadDiscipline">.</param>
        /// <param name="calculationSheetDiscipline">.</param>
        public void CalculateForNotLecture(TeacherLoadDiscipline teacherLoadDiscipline, CalculationSheetDiscipline calculationSheetDiscipline)
        {
            teacherLoadDiscipline.Semester = calculationSheetDiscipline.Semester;

            teacherLoadDiscipline.HoursLaboratoryWork = calculationSheetDiscipline.CountLaboratoryWork;
            teacherLoadDiscipline.HoursPracticum = calculationSheetDiscipline.HoursPracticum;
            teacherLoadDiscipline.HoursKpKr = calculationSheetDiscipline.HoursKpKr;
            teacherLoadDiscipline.HoursСontrolWork = calculationSheetDiscipline.HoursСontrolWork;

            teacherLoadDiscipline.HoursTest = calculationSheetDiscipline.HoursTest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherLoadDiscipline"></param>
        /// <param name="calculationSheetDiscipline"></param>
        public void CalculateDividerGroups(TeacherLoadDiscipline teacherLoadDiscipline, CalculationSheetDiscipline calculationSheetDiscipline)
        {
            foreach (var group in teacherLoadDiscipline.Groups)
            {
                if (!calculationSheetDiscipline.DividerGroups.ContainsKey(group.Name))
                {
                    calculationSheetDiscipline.DividerGroups[group.Name] = 0;
                }

                calculationSheetDiscipline.DividerGroups[group.Name]++;
            }
        }

        public void CheckFlags(TeacherLoadDiscipline teacherLoadDiscipline, CalculationSheetDiscipline calculationSheetDiscipline)
        {
            if (calculationSheetDiscipline.CountExam == 1)
            {
                teacherLoadDiscipline.TeacherLoadDisciplineFlags = teacherLoadDiscipline.TeacherLoadDisciplineFlags |
                    TeacherLoadDisciplineFlags.NasExam;
            }

            if (calculationSheetDiscipline.CountTest == 1 || calculationSheetDiscipline.CountDifferentiatedTest == 1)
            {
                teacherLoadDiscipline.TeacherLoadDisciplineFlags = teacherLoadDiscipline.TeacherLoadDisciplineFlags |
                    TeacherLoadDisciplineFlags.NasTest;
            }

            if (calculationSheetDiscipline.CountKp == 1)
            {
                teacherLoadDiscipline.TeacherLoadDisciplineFlags = teacherLoadDiscipline.TeacherLoadDisciplineFlags |
                    TeacherLoadDisciplineFlags.NasKp;
            }

            if (calculationSheetDiscipline.CountKr == 1)
            {
                teacherLoadDiscipline.TeacherLoadDisciplineFlags = teacherLoadDiscipline.TeacherLoadDisciplineFlags |
                    TeacherLoadDisciplineFlags.NasKr;
            }

            if (calculationSheetDiscipline.CountLaboratoryWork >0 )
            {
                teacherLoadDiscipline.TeacherLoadDisciplineFlags = teacherLoadDiscipline.TeacherLoadDisciplineFlags |
                    TeacherLoadDisciplineFlags.HasLab;
            }
        }
    }
}
