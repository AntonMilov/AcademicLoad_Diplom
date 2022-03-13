using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Core.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с моделью дисциплины преподовательской нагрузки.
    /// </summary>
    public interface ITeacherLoadDisciplineService
    {
        /// <summary>
        /// Добавление дисциплины преподовательской нагрузки.
        /// </summary>
        void AddTeacherLoadDiscipline(TeacherLoadDiscipline teacherLoadDiscipline, CalculationSheetDiscipline calculationSheetDiscipline);

        /// <summary>
        /// Удаление дисциплины преподовательской нагрузки.
        /// </summary>
        void DeleteTeacherLoadDiscipline(TeacherLoadDiscipline teacherLoadDiscipline, CalculationSheetDiscipline calculationSheetDiscipline);

        /// <summary>
        /// Дисциплины преподовательской нагрузки.
        /// </summary>
        List<TeacherLoadDiscipline> TeacherLoadDisciplines { get; set; }
    }
}
