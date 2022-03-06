namespace Data.Models
{
    /// <summary>
    /// Сущности дисциплины преподовательской нагрузки.
    /// </summary>
    public class TeacherLoadDiscipline
    {
        /// <summary>
        /// Преподавтель.
        /// </summary>
        public Teacher Teacher { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Semester { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Groups { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int StudentsBudget { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int StudentsContract { get; set; }

        #region Hours
        /// <summary>
        /// 
        /// </summary>
        public int HoursLecture { get; set; }

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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
