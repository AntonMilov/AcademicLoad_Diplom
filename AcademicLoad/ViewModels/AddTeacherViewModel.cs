using Data.Enums;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Data.Models;

namespace AcademicLoadModule.ViewModels
{
    /// <inheritdoc/>
    public class AddTeacherViewModel : BindableBase
    {
        private readonly DateTime StartDate = new DateTime(1940, 1, 1);
        private string firstName;
        private string lastName;
        private string middleName;
        private double rate = 5.00;
        private DateTime birthday;
        private AcademicTitle selectedAcademicTitle;
        private ObservableCollection<AcademicTitle> academicTitles;
        private ObservableCollection<Rate> rates;

        /// <summary>
        /// .ctor
        /// </summary>
        public AddTeacherViewModel()
        {
            academicTitles = new ObservableCollection<AcademicTitle>();
            rates = new ObservableCollection<Rate>();
            birthday = StartDate;

            foreach (AcademicTitle academicTitle in Enum.GetValues(typeof(AcademicTitle)))
            {
                if (academicTitle != AcademicTitle.None)
                {
                    AcademicTitles.Add(academicTitle);
                }
            }

            foreach (Rate rate in Enum.GetValues(typeof(Rate)))
            {
                Rates.Add(rate);
            }
        }

        /// <summary>
        /// Должности.
        /// </summary>
        public ObservableCollection<AcademicTitle> AcademicTitles
        {
            get => academicTitles;
            set => SetProperty(ref academicTitles, value);
        }

        /// <summary>
        /// Ставки.
        /// </summary>
        public ObservableCollection<Rate> Rates
        {
            get => rates;
            set => SetProperty(ref rates, value);
        }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string MiddleName
        {
            get => middleName;
            set => SetProperty(ref middleName, value);
        }

        /// <summary>
        /// Выбранная Должность.
        /// </summary>
        public AcademicTitle SelectedAcademicTitle
        {
            get => selectedAcademicTitle;
            set => SetProperty(ref selectedAcademicTitle, value);
        }

        /// <summary>
        /// Ставка.
        /// </summary>
        public double Rate
        {
            get => rate;
            set => SetProperty(ref rate, value);
        }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime Birthday
        {
            get => birthday;
            set => SetProperty(ref birthday, value);
        }

        /// <summary>
        /// Создание нового учителя.
        /// </summary>
        /// <returns></returns>
        public Teacher CreateTeacher()
        {
            return new Teacher()
            {
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                AcademicTitle = SelectedAcademicTitle,
                Rate = Rate,
                Birthday = Birthday
            };
        }

        /// <summary>
        /// Проверка на заполнение всех полей.
        /// </summary>
        /// <returns></returns>
        public bool CanAddTeacher()
        {
            return !string.IsNullOrEmpty(FirstName) &&
                   !string.IsNullOrEmpty(MiddleName) &&
                   !string.IsNullOrEmpty(LastName) &&
                   SelectedAcademicTitle != AcademicTitle.None &&
                   Rate != 5.00 &&
                   Birthday != StartDate;
        }
    }
}
