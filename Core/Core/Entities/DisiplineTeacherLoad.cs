using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    /// <summary>
    /// Сущности дисциплины преподовательской нагрузки.
    /// </summary>
    public class DisiplineTeacherLoad
    {
        public int Semester { get; set; }

        public string Groups { get; set; }

        public int StudentsBudget { get; set; }

        public int StudentsContract { get; set; }

        #region Hours
        public int HoursLecture { get; set; }

        public int HoursLaboratoryWork { get; set; }


        /// <summary>
        /// Часы отведенные для практики.
        /// </summary>
        public int HoursPracticum { get; set; }

        // КП, КР (так называется в таблице).
        public int HoursKpKr { get; set; }

        /// <summary>
        /// Часы отведенные для  контрольных работ.
        /// </summary>
        public int HoursСontrolWork { get; set; }

        public int HoursExam { get; set; }

        /// <summary>
        /// Часы отведенные для зачета.
        /// </summary>
        public int HoursTest { get; set; }

        public int HoursConsultation { get; set; }

        /// <summary>
        /// Часы под прочую нагрузку по ВПО.
        /// </summary>
        public int HoursOtherLoadVpO { get; set; }

        /// <summary>
        /// Часы отведенные для подготовки аспирантов, интернов, ординаторов.
        /// </summary>
        public int HoursTraining { get; set; }

        /// <summary>
        /// Всего осенний семестр.
        /// </summary>
        public int HoursTotalFallSemester { get; set; }

        /// <summary>
        /// Всего весенний семестр.
        /// </summary>
        public int HoursTotalSpringSemester { get; set; }

        /// <summary>
        /// Всего за год нагрузка.
        /// </summary>
        public int HoursTotalYearLoad { get; set; }
        #endregion
    }
}
