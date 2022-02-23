using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace AcademicLoadModule.Controllers.Interfaces
{
    /// <summary>
    /// Интерфейс контроллера для преподователей.
    /// </summary>
    public interface ITeacherController
    {
        /// <summary>
        /// Добавление преподователя.
        /// </summary>
        void AddTeacher();

        /// <summary>
        /// Добавление преподователя.
        /// </summary>
        ObservableCollection<Teacher> Items { get; set; }

    }
}
