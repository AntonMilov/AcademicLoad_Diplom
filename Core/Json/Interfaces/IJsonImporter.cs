using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Core.Json.Interfaces
{
    /// <summary>
    /// Интерфейс для импорта Json.
    /// </summary>
    public interface IJsonImporter
    {
        /// <summary>
        /// Загрузка списка групп из JSON.
        /// </summary>
        List<Group> LoadGroups();

        /// <summary>
        /// Загрузка преподавателей из JSON.
        /// </summary>
        List<Teacher> LoadTeachers();
    }
}
