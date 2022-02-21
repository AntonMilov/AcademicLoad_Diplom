using Core.Entities;
using Data.Enums;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace AcademicLoadModule.ViewModels
{
    /// <inheritdoc/>
    public class AddTeacherViewModel : BindableBase
    {
        private string firstName;
        private string lastName;
        private string middleName;
        private double rate;
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

            foreach (AcademicTitle academicTitle in Enum.GetValues(typeof(AcademicTitle)))
            {
                AcademicTitles.Add(academicTitle);
            }


            foreach (Rate rate in Enum.GetValues(typeof(Rate)))
            {
                Rates.Add(rate);
            }

            AddTeacherCommand = new DelegateCommand(AddTeacher, CanAddTeacher);
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

        public DelegateCommand AddTeacherCommand { get; set; }

        private void AddTeacher()
        {
            Debug.WriteLine("aza");

        }
        private bool CanAddTeacher()
        {
            return true;
        }
    }
}
