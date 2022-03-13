using System.Collections.Generic;
using System.ComponentModel;
using Data.Enums;
using Prism.Mvvm;

namespace Data.Models
{
    /// <summary>
    /// Модель назначения преподавателя к  дисциплине.
    /// </summary>
    public partial class TeacherLoadDiscipline : BindableBase, IDataErrorInfo
    {
        private const double maxValue = 400;

        private TeacherLoadDisciplineFlags teacherLoadDisciplineFlags;
        private Teacher teacher;
        private int semester;
        private List<Group> groups;
        private int studentsBudget;
        private int studentsContract;
        private double hoursLecture ;
        private double hoursLaboratoryWork ;
        private double hoursPracticum ;
        private double hoursKpKr ;
        private double hoursСontrolWork ;
        private double hoursExam ;
        private double hoursTest ;
        private double hoursConsultation ;
        private double hoursOtherLoadVpo ;
        private double hoursTraining ;
        private double hoursTotalFallSemester ;
        private double hoursTotalSpringSemester ;
        private double hoursTotalYearLoad ;

        private double hoursLectureMaxValue= maxValue;
        private double hoursLaboratoryWorkMaxValue = maxValue;
        private double hoursPracticumMaxValue = maxValue;
        private double hoursKpKrMaxValue = maxValue;
        private double hoursСontrolWorkMaxValue = maxValue;
        private double hoursExamMaxValue = maxValue;
        private double hoursTestMaxValue = maxValue;

        /// <summary>
        /// ctor.
        /// </summary>
        public TeacherLoadDiscipline()
        {
            PropertyChanged += new PropertyChangedEventHandler(PropertyChangedHandler);
        }

        /// <summary>
        /// Флаги.
        /// </summary>
        public TeacherLoadDisciplineFlags TeacherLoadDisciplineFlags
        {
            get => teacherLoadDisciplineFlags;
            set => SetProperty(ref teacherLoadDisciplineFlags, value);
        }

        /// <summary>
        /// Преподавтель.
        /// </summary>
        public Teacher Teacher
        {
            get => teacher;
            set => SetProperty(ref teacher, value);
        }

        /// <summary>
        /// Семестр.
        /// </summary>
        public int Semester
        {
            get => semester;
            set => SetProperty(ref semester, value);
        }

        /// <summary>
        /// Группы.
        /// </summary>
        public List<Group> Groups
        {
            get => groups;
            set => SetProperty(ref groups, value);
        }

        /// <summary>
        /// Студенты на бюджетной основе.
        /// </summary>
        public int StudentsBudget
        {
            get => studentsBudget;
            set => SetProperty(ref studentsBudget, value);
        }

        /// <summary>
        /// Студенты на договорной основе.
        /// </summary>
        public int StudentsContract
        {
            get => studentsContract;
            set => SetProperty(ref studentsContract, value);
        }

        private void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            СalculationHoursTotalFallSemester();
            СalculationHoursTotalSpringSemester();
            СalculationHoursTotalYearLoad();
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
