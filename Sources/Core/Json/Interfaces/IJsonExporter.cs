using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Core.Json.Interfaces
{
    /// <summary>
    /// Интерфейс для экспорта Json.
    /// </summary>
    public interface IJsonExporter
    {
        /// <summary>
        /// Сохранение списка групп в JSON.
        /// </summary>
        void SaveGroups(List<Group> groups);

        /// <summary>
        /// Сохранение списка преподавателей в JSON.
        /// </summary>
        void SaveTeachers(List<Teacher> groups);

    }
}
