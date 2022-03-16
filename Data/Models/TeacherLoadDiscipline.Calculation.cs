using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /// <summary>
    /// Модель назначения преподавателя к  дисциплине.
    /// </summary>
    public partial class TeacherLoadDiscipline
    {
        /// <summary>
        /// Функция обновления
        /// </summary>
        public void Update()
        {
            CalculateHoursTest();
            CalculateHoursKp();
            CalculateHoursKr();
        }

        private void CalculateHoursTest()
        {
            if (!TeacherLoadDisciplineFlags.HasFlag(Enums.TeacherLoadDisciplineFlags.NasTest))
            {
                return;
            }

            HoursTest = 0;
            foreach (var group in groups)
            {
                HoursTest = HoursTest + CalculateStudents(group) * NormsOfTime.StudentsTest;
            }
        }

        private void CalculateHoursKp()
        {
            if (!TeacherLoadDisciplineFlags.HasFlag(Enums.TeacherLoadDisciplineFlags.NasKp))
            {
                return;
            }

            HoursKpKr = 0;
            foreach (var group in groups)
            {
                HoursKpKr = HoursKpKr + CalculateStudents(group) * NormsOfTime.Kp;
            }
        }

        private void CalculateHoursKr()
        {
            if (!TeacherLoadDisciplineFlags.HasFlag(Enums.TeacherLoadDisciplineFlags.NasKr))
            {
                return;
            }

            HoursKpKr = 0;
            foreach (var group in groups)
            {
                HoursKpKr = HoursKpKr + CalculateStudents(group) * NormsOfTime.Kr;
            }
        }

        private double CalculateStudents(Group group)
        {
            double calculateStudents = (double)group.Students / DividerGroups[group.Name];

            if (TeacherLoadDisciplineFlags.HasFlag(Enums.TeacherLoadDisciplineFlags.IsMainLecture))
            {
                return (int)Math.Ceiling(calculateStudents);
            }
            else
            {
                return (int)calculateStudents;
            }
        }


        private void СalculationHoursTotalFallSemester()
        {
            if (Semester % 2 == 1)
            {
                HoursTotalFallSemester = HoursLecture +
                     HoursLaboratoryWork +
                     HoursPracticum + HoursKpKr +
                     HoursСontrolWork +
                     HoursExam +
                     HoursTest +
                     HoursConsultation +
                     HoursOtherLoadVpo +
                     HoursTraining;
                return;
            }

            HoursTotalFallSemester = 0;
        }

        private void СalculationHoursTotalSpringSemester()
        {
            if (Semester % 2 == 0)
            {
                HoursTotalSpringSemester = HoursLecture +
                     HoursLaboratoryWork +
                     HoursPracticum + HoursKpKr +
                     HoursСontrolWork +
                     HoursExam +
                     HoursTest +
                     HoursConsultation +
                     HoursOtherLoadVpo +
                     HoursTraining;
                return;
            }

            HoursTotalSpringSemester = 0;
        }

        private void СalculationHoursTotalYearLoad()
        {
            HoursTotalYearLoad = HoursTotalFallSemester + HoursTotalSpringSemester;
        }



    }
}
