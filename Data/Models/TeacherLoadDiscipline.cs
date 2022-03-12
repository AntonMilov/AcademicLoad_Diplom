using System;
using System.ComponentModel;
using Prism.Mvvm;

namespace Data.Models
{
    /// <summary>
    /// Модель назначения преподавателя к  дисциплине.
    /// </summary>
    public partial class TeacherLoadDiscipline : BindableBase, IDataErrorInfo
    {
        private const double  maxValue = 400;

        private Teacher teacher;
        private int semester;
        private string groups;
        private int studentsBudget;
        private int studentsContract;
        private double hoursLecture = maxValue;
        private double hoursLaboratoryWork = maxValue;
        private double hoursPracticum = maxValue;
        private double hoursKpKr = maxValue;
        private double hoursСontrolWork = maxValue;
        private double hoursExam = maxValue;
        private double hoursTest = maxValue;
        private double hoursConsultation = maxValue;
        private double hoursOtherLoadVpo = maxValue;
        private double hoursTraining = maxValue;
        private double hoursTotalFallSemester = maxValue;
        private double hoursTotalSpringSemester = maxValue;
        private double hoursTotalYearLoad = maxValue;

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
        public string Groups
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
    }
}
