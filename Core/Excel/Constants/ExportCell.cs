using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Excel.Constants
{
    /// <summary>
    /// 
    /// Без смещения
    /// </summary>
    public class ExportCell
    {
        /// <summary>
        /// "Пензенский государственный университет" начало объединения.
        /// </summary>
        public readonly CellRowColumn NamePzuStart = new CellRowColumn(2, 4);

        /// <summary>
        /// "Пензенский государственный университет" конец объединения.
        /// </summary>
        public readonly CellRowColumn NamePzuEnd = new CellRowColumn(2, 15);

        /// <summary>
        /// "Распределение учебной нагрузки" начало объединения.
        /// </summary>
        public readonly CellRowColumn DistributionTeacherLoadStart = new CellRowColumn(4, 3);
        /// <summary>
        /// "Распределение учебной нагрузки" конец объединения.
        /// </summary>
        public readonly CellRowColumn DistributionTeacherLoadEnd = new CellRowColumn(4, 12);

        /// <summary>
        /// "Кафедра".
        /// </summary>
        public readonly CellRowColumn Department = new CellRowColumn(6, 1);

        /// <summary>
        /// "Учебный год".
        /// </summary>
        public readonly CellRowColumn AcademicYear = new CellRowColumn(8, 1);

        /// <summary>
        /// "Cр. год. нагрузка".
        /// </summary>
        public readonly CellRowColumn СfYearLoad = new CellRowColumn(8, 4);

        /// <summary>
        /// "Утверждаю".
        /// </summary>
        public readonly CellRowColumn Approve = new CellRowColumn(3, 17);

        /// <summary>
        /// "Проректор".
        /// </summary>
        public readonly CellRowColumn Prorector = new CellRowColumn(4, 15);

        /// <summary>
        /// "Ф.И.О.".
        /// </summary>
        public readonly CellRowColumn Initials = new CellRowColumn(10, 1);

        /// <summary>
        /// "Должность".
        /// </summary>
        public readonly CellRowColumn AcademicTitle = new CellRowColumn(10, 9);

        /// <summary>
        /// "Ставка".
        /// </summary>
        public readonly CellRowColumn Rate = new CellRowColumn(10, 17);

        /// <summary>
        /// "Итого".
        /// </summary>
        public readonly CellRowColumn Total = new CellRowColumn(12, 2);

        /// <summary>
        /// Начальная позиция для ячеек формул по расчету итоговых значений.
        /// </summary>
        public readonly CellRowColumn TotalStartFormula = new CellRowColumn(12, 4);

        /// <summary>
        /// Начальная позиция для ячеек шапки дисциплин.
        /// </summary>
        public readonly CellRowColumn HeaderTeacherLoadDiscipline = new CellRowColumn(14, 1);

        /// <summary>
        /// Начальная позиция для ячеек преподовательской нагрузки.
        /// </summary>
        public readonly CellRowColumn TeacherLoadDiscipline = new CellRowColumn(15, 1);

        /// <summary>
        /// Начальная позиция для ячеек шапки списка преподавателей в итоговом листе.
        /// </summary>
        public readonly CellRowColumn MainSheetStartHeaderListTeacher = new CellRowColumn(12, 2);

        /// <summary>
        /// Начальная позиция для ячеек  списка преподавателей в итоговом листе.
        /// </summary>
        public readonly CellRowColumn MainSheetStartListTeacher = new CellRowColumn(13, 1);
    }
}
