using System;
using Data.Enums;

namespace Data.Models
{
    /// <summary>
    /// Сущность преподователя.
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
        public double Rate { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime Birthday { get; set; }

    }
}
