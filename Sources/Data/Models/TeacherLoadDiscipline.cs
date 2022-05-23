using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Data.Enums;
using Prism.Mvvm;

namespace Data.Models
{
    /// <summary>
    /// Модель назначения преподавателя к  дисциплине.
    /// </summary>
    public partial class TeacherLoadDiscipline : BindableBase
    {
        private const double maxValue = 400;

        private TeacherLoadDisciplineFlags teacherLoadDisciplineFlags;
        private Teacher teacher;
        private int semester;
        private List<Group> groups;
        private int studentsBudget;
        private int studentsContract;
        private double hoursLecture;
        private double hoursLaboratoryWork;
        private double hoursPracticum;
        private double hoursKpKr;
        private double hoursСontrolWork;
        private double hoursExam;
        private double hoursTest;
        private double hoursConsultation;
        private double hoursOtherLoadVpo;
        private double hoursTraining;
        private double hoursTotalFallSemester;
        private double hoursTotalSpringSemester;
        private double hoursTotalYearLoad;

        private double hoursLectureMaxValue = maxValue;
        private double hoursLaboratoryWorkMaxValue = maxValue;
        private double hoursPracticumMaxValue = maxValue;
        private double hoursKpKrMaxValue = maxValue;
        private double hoursСontrolWorkMaxValue = maxValue;
        private double hoursExamMaxValue = maxValue;
        private double hoursTestMaxValue = maxValue;
        private double hoursConsultationMaxValue = maxValue;
        private double hoursOtherLoadVpoMaxValue = maxValue;
        private double hoursTrainingMaxValue = maxValue;

        private List<String> ignoredProperty = new List<string> { nameof(hoursTotalYearLoad), nameof(hoursTotalSpringSemester), nameof(hoursTotalFallSemester) };

        /// <summary>
        /// ctor.
        /// </summary>
        public TeacherLoadDiscipline()
        {
            PropertyChanged += new PropertyChangedEventHandler(PropertyChangedHandler);
            NormsOfTime.PropertyChanged += new PropertyChangedEventHandler(PropertyChangedNormsOfTimeHandler);
        }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, int> DividerGroups;

        /// <summary>
        /// Флаги.
        /// </summary>
        public TeacherLoadDisciplineFlags TeacherLoadDisciplineFlags
        {
            get => teacherLoadDisciplineFlags;
            set => SetProperty(ref teacherLoadDisciplineFlags, value);
        }

        /// <summary>
        /// Наименование дисциплины.
        /// </summary>
        public string NameDiscipine { get; set; }

        /// <summary>
        /// Преподавтель.
        /// </summary>
        public Teacher Teacher
        {
            get => teacher;
            set
            {
                SetProperty(ref teacher, value);
                Teacher.PropertyChanged += new PropertyChangedEventHandler(PropertyChangedTeacherHandler);
            }
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
            set
            {
                SetProperty(ref groups, value);

                StudentsContract = Groups.Sum(x => x.StudentsContract);
                StudentsBudget = Groups.Sum(x => x.StudentsBudget);

                foreach (Group group in Groups)
                {
                    group.PropertyChanged += new PropertyChangedEventHandler(PropertyChangedGroupHandler);
                }
            }
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
            if (ignoredProperty.Contains(e.PropertyName))
            {
                return;
            }

            СalculationHoursTotalFallSemester();
            СalculationHoursTotalSpringSemester();
            СalculationHoursTotalYearLoad();
        }

        private void PropertyChangedGroupHandler(object sender, PropertyChangedEventArgs e)
        {
            StudentsContract = Groups.Sum(x => x.StudentsContract);
            StudentsBudget = Groups.Sum(x => x.StudentsBudget);

            RaisePropertyChanged(nameof(Groups));
        }

        private void PropertyChangedTeacherHandler(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(Teacher));
        }

        private void PropertyChangedNormsOfTimeHandler(object sender, PropertyChangedEventArgs e)
        {
            Update();
        }

    }
}
