﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Enums;

namespace Core.Entities
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
        DateTime Birthday { get; set; }

    }
}
