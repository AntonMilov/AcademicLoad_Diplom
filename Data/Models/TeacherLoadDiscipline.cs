namespace Data.Models
{
    /// <summary>
    /// Модель дисциплины преподовательской нагрузки.
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
        public double HoursLecture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double HoursLaboratoryWork { get; set; }

        /// <summary>
        /// Часы отведенные для практики.
        /// </summary>
        public double HoursPracticum { get; set; }

        /// <summary>
        /// КП, КР (так называется в таблице).
        /// </summary>
        public double HoursKpKr { get; set; }

        /// <summary>
        /// Часы отведенные для  контрольных работ.
        /// </summary>
        public double HoursСontrolWork { get; set; }

        public double HoursExam { get; set; }

        /// <summary>
        /// Часы отведенные для зачета.
        /// </summary>
        public double HoursTest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double HoursConsultation { get; set; }

        /// <summary>
        /// Часы под прочую нагрузку по ВПО.
        /// </summary>
        public double HoursOtherLoadVpo { get; set; }

        /// <summary>
        /// Часы отведенные для подготовки аспирантов, интернов, ординаторов.
        /// </summary>
        public double HoursTraining { get; set; }

        /// <summary>
        /// Всего осенний семестр.
        /// </summary>
        public double HoursTotalFallSemester { get; set; }

        /// <summary>
        /// Всего весенний семестр.
        /// </summary>
        public double HoursTotalSpringSemester { get; set; }

        /// <summary>
        /// Всего за год нагрузка.
        /// </summary>
        public double HoursTotalYearLoad { get; set; }
        #endregion
    }
}
