namespace Data.Models
{
    /// <summary>
    /// Модель для строк в таблице расчетного листа кафедральной нагрузки.
    /// </summary>
    public partial class CalculationSheetDiscipline
    {
        /// <summary>
        /// Индекс.
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Семестр.
        /// </summary>
        public int Semester { get; set; }

        /// <summary>
        /// Длительность семестр.
        /// </summary>
        public string LengthSemester { get; set; }

        /// <summary>
        /// Количество групп
        /// </summary>
        public int CountGroups { get; set; }

        /// <summary>
        /// Учебные групы.
        /// </summary>
        public string Groups { get; set; }

        /// <summary>
        /// Поток.
        /// </summary>
        public string Stream { get; set; }

        /// <summary>
        /// Поток практические + лабораторные.
        /// </summary>
        public string StreamPracticumLabrotory { get; set; }

        /// <summary>
        /// Количество студентов на бюджетной основе.
        /// </summary>
        public int StudentsBudget { get; set; }

        /// <summary>
        /// Количество студентов на договорной основе.
        /// </summary>
        public int StudentsContract { get; set; }

        #region CountLessons
        /// <summary>
        /// 
        /// </summary>
        public int CountLecture { get; set; }

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        public int CountExam { get; set; }

        /// <summary>
        /// Количество зачетов.
        /// </summary>
        public int CountTest { get; set; }

        /// <summary>
        /// Количество зачетов с оценкой.
        /// </summary>
        public int CountDifferentiatedTest { get; set; }

        /// <summary>
        /// Прочее.
        /// </summary>
        public int CountEtc { get; set; }
        #endregion

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
        /// Часы отведенные для практических занятий.
        /// </summary>
        public double HoursPracticumLesson { get; set; }

        /// <summary>
        /// КП, КР (так называется в таблице).
        /// </summary>
        public double HoursKpKr { get; set; }

        /// <summary>
        /// Часы отведенные для контрольных работ.
        /// </summary>
        public double HoursСontrolWork { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double HoursExam { get; set; }

        /// <summary>
        /// Часы отведенные для зачета, зачета с оценкой.
        /// </summary>
        public double HoursTest { get; set; }

        /// <summary>
        ///  Часы отведенные для консультации.
        /// </summary>
        public double HoursConsultation { get; set; }

        /// <summary>
        /// Часы отведенные для Гиа.
        /// </summary>
        public double HoursGia { get; set; }

        /// <summary>
        /// Часы отведенные для Практики (Рук-водитель).
        /// </summary>
        public double HoursPracticum { get; set; }

        /// <summary>
        /// Всего часов.
        /// </summary>
        public double HoursTotal { get; set; }
        #endregion
    }
}
