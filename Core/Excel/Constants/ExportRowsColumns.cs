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
    public class ExportRowsColumns
    {
        /// <summary>
        /// "Пензенский государственный университет"
        /// </summary>
        public readonly CellRowColumn NamePzuStart = new CellRowColumn(2, 4);
        public readonly CellRowColumn NamePzuEnd = new CellRowColumn(2, 15);

        /// <summary>
        /// "Распределение учебной нагрузки"
        /// </summary>
        public readonly CellRowColumn DistributionTeacherLoadStart = new CellRowColumn(4, 3);
        public readonly CellRowColumn DistributionTeacherLoadEnd = new CellRowColumn(4, 12);

        /// <summary>
        /// "Кафедра"
        /// </summary>
        public readonly CellRowColumn Department = new CellRowColumn(6, 1);

        /// <summary>
        /// "Учебный год"
        /// </summary>
        public readonly CellRowColumn AcademicYear = new CellRowColumn(8, 1);

        /// <summary>
        /// "Утверждаю"
        /// </summary>
        public readonly CellRowColumn Approve = new CellRowColumn(3, 17);

        /// <summary>
        /// "Проректор"
        /// </summary>
        public readonly CellRowColumn Prorector = new CellRowColumn(4, 15);
    }
}
