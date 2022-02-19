using Core.Entities;
using Data.Enums;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            foreach (AcademicTitle academicTitle in Enum.GetValues(typeof(AcademicTitle)))
            {
                academicTitles.Add(academicTitle);
            }
        }

        /// <summary>
        /// Должности
        /// </summary>
        public ObservableCollection<AcademicTitle> AcademicTitles
        {
            get => academicTitles;
            set => SetProperty(ref academicTitles, value);
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
            get => firstName;
            set => SetProperty(ref firstName, value);
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
    }
}
