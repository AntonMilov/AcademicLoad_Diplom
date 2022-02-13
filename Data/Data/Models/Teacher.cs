using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;

namespace Core.Entities
{
    /// <summary>
    /// Сущность преподователя.
    /// </summary>
    class Teacher
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
        public string MiddleNName { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        public AcademicTitle AcademicTitle { get; set; }

        /// <summary>
        /// Ставка.
        /// </summary>
        public double Rate { get; set; }

    }
}
