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
        /// Удаление преподователя.
        /// </summary>
        void DeleteTeacher(Teacher teacher);

        /// <summary>
        /// Редактирование преподавателя.
        /// </summary>
        void EditTeacher(Teacher teacher);

        /// <summary>
        /// Преподователи.
        /// </summary>
        ObservableCollection<Teacher> Items { get; set; }

        /// <summary>
        /// Проверка кол-ва учебных групп.
        /// </summary>
        void CheckTeacherCount();

    }
}
