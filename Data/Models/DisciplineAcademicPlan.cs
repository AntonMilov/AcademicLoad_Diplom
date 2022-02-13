using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    /// <summary>
    /// Сущности для строк в таблице по плану учебной нагрузки
    /// </summary>
    public class DisciplineAcademicPlan
    {
        public string Index { get; set; }

        public string Name { get; set; }

        public int Semester { get; set; }

        public int Length { get; set; }

        public int NumberGroups { get; set; }

        public string Groups { get; set; }

        /// <summary>
        /// Поток.
        /// </summary>
        public string Stream { get; set; }

        public int StudentsBudget { get; set; }

        public int StudentsContract { get; set; }

        #region CountLessons
        public int CountLecture { get; set; }

        public int CountLaboratoryWork { get; set; }

        /// <summary>
        /// Количество практических занятий.
        /// </summary>
        public int CountPracticum { get; set; }

        /// <summary>
        /// Количество КП (так называется в таблице).
        /// </summary>
        public int CountKp { get; set; }

        /// <summary>
        /// Количество КР (так называется в таблице).
        /// </summary>
        public int CountKr { get; set; }

        /// <summary>
        /// Количество контрольных работ.
        /// </summary>
        public int CountСontrolWork { get; set; }

        public int CountExam { get; set; }

        /// <summary>
        /// Количество зачетов.
        /// </summary>
        public int CountTest { get; set; }
        #endregion

        /// <summary>
        /// Прочее.
        /// </summary>
        public int Etc { get; set; }

        #region Hours
        public int HoursLecture { get; set; }

        public int HoursLaboratoryWork { get; set; }

        /// <summary>
        /// Часы отведенные для практических занятий.
        /// </summary>
        public int HoursPracticumLesson { get; set; }

        /// <summary>
        /// КП, КР (так называется в таблице).
        /// </summary>
        public int HoursKpKr { get; set; }

        /// <summary>
        /// Часы отведенные для контрольных работ.
        /// </summary>
        public int HoursСontrolWork { get; set; }

        public int HoursExam { get; set; }

        /// <summary>
        /// Часы отведенные для зачета.
        /// </summary>
        public int HoursTest { get; set; }

        public int HoursConsultation { get; set; }

        /// <summary>
        /// Часы отведенные для Гиа.
        /// </summary>
        public int HoursGia { get; set; }

        /// <summary>
        /// Часы отведенные для Практики.
        /// </summary>
        public int HoursPracticum { get; set; }

        /// <summary>
        /// Всего часов.
        /// </summary>
        public int HoursTotal { get; set; }
        #endregion
    }
}
