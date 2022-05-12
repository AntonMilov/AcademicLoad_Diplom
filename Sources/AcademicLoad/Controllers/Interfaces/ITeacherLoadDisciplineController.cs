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
    /// Интерфейс контроллера для дисциплин преподовательской нагрузки..
    /// </summary>
    public interface ITeacherLoadDisciplineController
    {
        /// <summary>
        /// Добавление дисциплины преподовательской нагрузки.
        /// </summary>
        void AddTeacherLoadDiscipline(CalculationSheetDiscipline calculationSheetDiscipline);

        /// <summary>
        /// Удаление дисциплины преподовательской нагрузки.
        /// </summary>
        void DeleteTeacherLoadDiscipline(TeacherLoadDiscipline teacherLoadDiscipline, CalculationSheetDiscipline calculationSheetDiscipline);

        /// <summary>
        /// Дисциплины преподовательской нагрузки.
        /// </summary>
        List<TeacherLoadDiscipline> Items { get; set; }
    }
}
