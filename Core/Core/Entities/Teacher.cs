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
        /// Фамилия с инициалами.
        /// </summary>
        public string LastNameInitials { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        public  AcademicTitle AcademicTitle { get; set; }
        
        /// <summary>
        /// Ставка.
        /// </summary>
        public double Rate { get; set; }

    }
}
