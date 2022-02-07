using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DisciplineAcademicPlan
    {
        public string Index { get; set; }

        public string Name { get; set; }

        public int Semester { get; set; }

        public int Length { get; set; }

        public int NumberGroups { get; set; }

        public string Groups { get; set; }

        //Поток.
        public string Stream { get; set; }

        public int StudentsBudget { get; set; }

        public int StudentsContract { get; set; }

        #region CountLessons
        public int CountLecture { get; set; }

        public int CountLaboratoryWork { get; set; }

        //Практическое занятие.
        public int CountPracticum { get; set; }

        // КП (так называется в таблице).
        public int CountKp { get; set; }

        // КР (так называется в таблице).
        public int CountKr { get; set; }

        //Контрольная работа
        public int CountСontrolWork { get; set; }

        public int CountExam { get; set; }

        //Зачет.
        public int CountTest { get; set; }
        #endregion

        //Прочее.
        public int Etc { get; set; }

        #region Hours
        public int HoursLecture { get; set; }

        public int HoursLaboratoryWork { get; set; }

        //Практическое занятие.
        public int HoursPracticumLesson { get; set; }

        // КП, КР (так называется в таблице).
        public int HoursKpKr { get; set; }
        
        //Контрольная работа
        public int HoursСontrolWork { get; set; }

        public int HoursExam { get; set; }

        //Зачет.
        public int HoursTest { get; set; }

        public int HoursConsultation { get; set; }

        //Гиа.
        public int HoursGia { get; set; }

        //Практика.
        public int HoursPracticum { get; set; }

        //Всего часов.
        public int HoursTotal { get; set; }
        #endregion
    }
}
