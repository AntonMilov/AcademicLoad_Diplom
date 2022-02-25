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
        /// Добавление преподователя.
        /// </summary>
        void AddGroup();

        /// <summary>
        /// Преподователи.
        /// </summary>
        ObservableCollection<Group> Items { get; set; }
    }
}
