using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Core.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с моделью преподавателя.
    /// </summary>
    public interface ITeacherService
    {
        /// <summary>
        /// Добавление преподавателя.
        /// </summary>
        /// <param name="teacher"></param>
        void AddTeacher(Teacher teacher);

        /// <summary>
        /// Преподаватели.
        /// </summary>
        ICollection<Teacher> Teachers { get; set; }
    }
}
