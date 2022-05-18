using System;
using System.IO;
using Data.Enums;
using Prism.Mvvm;

namespace Data.Models
{
    /// <summary>
    /// Модель преподователя.
    /// </summary>
    public class Teacher : BindableBase
    {
        private string firstName;
        private string lastName;
        private string middleName;
        private AcademicTitle academicTitle;
        private Rate rate;
        private DateTime birthday;
        private string photoPath;

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
        /// Должность.
        /// </summary>
        public AcademicTitle AcademicTitle
        {
            get => academicTitle;
            set => SetProperty(ref academicTitle, value);
        }

        /// <summary>
        /// Ставка.
        /// </summary>
        public Rate Rate
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
        /// Путь к фотографии.
        /// </summary>
        public string PhotoPath
        {
            get => photoPath;
            set
            {
                if (File.Exists(value))
                {
                    SetProperty(ref photoPath, value);
                    return;
                }

                SetProperty(ref photoPath, null);
            }
        }
    }
}
