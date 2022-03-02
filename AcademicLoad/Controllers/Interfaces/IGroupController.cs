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
    /// Интерфейс контроллера для учебных групп.
    /// </summary>
    public interface IGroupController
    {
        /// <summary>
        /// Добавление учебной группы.
        /// </summary>
        void AddGroup();

        /// <summary>
        /// Учебные группы.
        /// </summary>
        ObservableCollection<Group> Items { get; set; }

        /// <summary>
        /// Проверка кол-ва учебных групп.
        /// </summary>
        void CheckGroupsCount();
    }
}
