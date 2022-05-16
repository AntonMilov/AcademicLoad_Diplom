using System;
using Data.Enums;

namespace Data.Models
{
    /// <summary>
    /// Модель преподователя.
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        public AcademicTitle AcademicTitle { get; set; }

        /// <summary>
        /// Ставка.
        /// </summary>
        public Rate Rate { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Путь к фотографии.
        /// </summary>
        public string PhotoPath { get; set; } = null;

    }
}
