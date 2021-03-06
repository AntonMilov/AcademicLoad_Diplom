using System.Collections.Generic;
using Data.Models;

namespace Core.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с моделью учебной группы.
    /// </summary>
    public interface IGroupService
    {
        /// <summary>
        /// Добавление учебной группы.
        /// </summary>
        /// <param name="teacher"></param>
        void AddGroup(Group group);

        /// <summary>
        /// Удаление учебной группы.
        /// </summary>
        void DeleteGroup(Group group);

        /// <summary>
        /// Сохранение изменений  учебной группы.
        /// </summary>
        void SaveEditGroup();

        /// <summary>
        /// Учебные группы.
        /// </summary>
        List<Group> Groups { get; set; }
    }
}
