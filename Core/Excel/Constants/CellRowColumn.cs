using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Excel.Constants
{
    /// <summary>
    /// Структура для хранения номера строки и столбца ячейки в Excel.
    /// </summary>
    public struct CellRowColumn
    {
        public int row;
        public int column;

        public CellRowColumn(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
    }
}
