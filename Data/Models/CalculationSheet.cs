
using System.Collections.Generic;

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
        public double TotalStudentsBudget { get; set; }
        /// <summary>
        /// Всего договорников.
        /// </summary>
        public double TotalStudentsContract { get; set; }
        
        /// <summary>
        /// Всегоа часов.
        /// </summary>
         public double TotalHours { get; set; }

        #region TotalHours
        /// <summary>
        /// Всего часов лекций.
        /// </summary>
        public double TotalHoursLecture { get; set; }

        /// <summary>
        /// Всего часов лабораторных.
        /// </summary>
        public double TotalHoursLaboratory { get; set; }

        /// <summary>
        /// Всего часов практических занятий.
        /// </summary>
        public double TotalHoursPracticalWorks { get; set; }
       
        /// <summary>
        /// Всего часов КП,КР.
        /// </summary>
        public double TotalHoursKpKr { get; set; }
       
        /// <summary>
        /// Всего часов контрольных работ.
        /// </summary>
        public double TotalHoursControlWorks { get; set; }
       
        /// <summary>
        /// Всего часов экзаменов.
        /// </summary>
        public double TotalHoursExam { get; set; }
       
        /// <summary>
        /// Всего засов зачетов.
        /// </summary>
        public double TotalHoursTest { get; set; }
        
        /// <summary>
        /// Всего часов консультаций.
        /// </summary>
        public double TotalHoursСonsultation { get; set; }
       
        /// <summary>
        /// Всего часов пратики
        /// </summary>
        public double TotalHoursPracticum { get; set; }
       
        /// <summary>
        /// Всего часов ГИА
        /// </summary>
        public double TotalHoursGia { get; set; }
        #endregion

        public List<CalculationSheetDiscipline> CalculationSheetDisciplines { get; set; }
    }
}
