
namespace Data.Models
{
    /// <summary>
    /// Модель расчетного листа кафедральной нагрузки.
    /// </summary>
    public class CalculationSheet
    {
        /// <summary>
        /// Имя файла.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Кафедра.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Факультет.
        /// </summary>
        public string Faculty { get; set; }

        /// <summary>
        /// Учебный год
        /// </summary>
         public string AcademicYear { get; set; }

        /// <summary>
        /// Всего бюджетников.
        /// </summary>
        public int TotalStudentsBudget { get; set; }
        /// <summary>
        /// Всего договорников.
        /// </summary>
        public int TotalStudentsContract { get; set; }
        
        /// <summary>
        /// Всегоа часов.
        /// </summary>
         public int TotalHours { get; set; }

        #region TotalHours
        /// <summary>
        /// Всего часов лекций.
        /// </summary>
        public int TotalHoursLecture { get; set; }

        /// <summary>
        /// Всего часов лабораторных.
        /// </summary>
        public int TotalHoursLaboratory { get; set; }

        /// <summary>
        /// Всего часов практических занятий.
        /// </summary>
        public int TotalHoursPracticalWorks { get; set; }
       
        /// <summary>
        /// Всего часов КП,КР.
        /// </summary>
        public int TotalHoursKpKr { get; set; }
       
        /// <summary>
        /// Всего часов контрольных работ.
        /// </summary>
        public int TotalHoursControlWorks { get; set; }
       
        /// <summary>
        /// Всего часов экзаменов.
        /// </summary>
        public int TotalHoursExam { get; set; }
       
        /// <summary>
        /// Всего засов зачетов.
        /// </summary>
        public int TotalHoursTest { get; set; }
        
        /// <summary>
        /// Всего часов консультаций.
        /// </summary>
        public int TotalHoursСonsultation { get; set; }
       
        /// <summary>
        /// Всего часов пратики
        /// </summary>
        public int TotalHoursPracticum { get; set; }
       
        /// <summary>
        /// Всего часов ГИА
        /// </summary>
        public int TotalHoursGia { get; set; }
        #endregion
    }
}
