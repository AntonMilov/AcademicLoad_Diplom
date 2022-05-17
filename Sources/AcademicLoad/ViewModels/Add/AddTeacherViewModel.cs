using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Core.Photo;
using Data.Enums;
using Data.Models;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;

namespace AcademicLoadModule.ViewModels.Add
{
    /// <inheritdoc/>
    public class AddTeacherViewModel : BindableBase
    {   
        private readonly IPhotoService photoService;
        private readonly OpenFileDialog openFileDialog;
        private readonly DateTime StartDate = new DateTime(1940, 1, 1);
        private string firstName;
        private string lastName;
        private string middleName;
        private string photoPath = null;
        private Rate _selectedSelectedRate;
        private DateTime birthday;
        private AcademicTitle selectedAcademicTitle;
        private ObservableCollection<AcademicTitle> academicTitles;
        private ObservableCollection<Rate> rates;
     
        /// <summary>
        /// .ctor
        /// </summary>
        public AddTeacherViewModel(IPhotoService photoService, OpenFileDialog openFileDialog)
        {
            this.photoService = photoService;
            this.openFileDialog = openFileDialog;

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
                if (rate != Rate.None)
                {
                    Rates.Add(rate);
                }
            }
        }

        /// <summary>
        /// Команда для добавления фотографии.
        /// </summary>
        public DelegateCommand AddPhotoCommand => new DelegateCommand(AddPhoto);

        /// <summary>
        /// Команда для удаления фотографии.
        /// </summary>
        public DelegateCommand DeletePhotoCommand => new DelegateCommand(DeletePhoto);

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
        public Rate SelectedRate
        {
            get => _selectedSelectedRate;
            set => SetProperty(ref _selectedSelectedRate, value);
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
        /// Путь фотографии.
        /// </summary>
        public string PhotoPath
        {
            get => photoPath;
            set => SetProperty(ref photoPath, value);
        }

        /// <summary>
        /// Создание нового учителя.
        /// </summary>
        public Teacher CreateTeacher()
        {
            return new Teacher()
            {
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                AcademicTitle = SelectedAcademicTitle,
                Rate = SelectedRate,
                Birthday = Birthday,
                PhotoPath = PhotoPath
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
                   SelectedRate != Rate.None &&
                   Birthday != StartDate;
        }

        private void AddPhoto()
        {
            string photoExtensions = "*.jpg;*.jpeg";
            openFileDialog.Filter = $"JPG и JPEG-файлы ({photoExtensions})|{photoExtensions}";

            if (openFileDialog.ShowDialog() == true)
            {
               PhotoPath = photoService.AddPhoto(openFileDialog.FileName);
            }
        }


        private void DeletePhoto()
        {
            photoService.DeletePhoto(PhotoPath);
        }
    }
}
