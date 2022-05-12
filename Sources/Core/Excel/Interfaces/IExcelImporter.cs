using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Core.Excel.Interfaces
{
    /// <summary>
    /// Интерфейс для импорта Excel.
    /// </summary>
    public interface IExcelImporter
    {
        /// <summary>
        /// Импортиовать расчетный лист кафедральной нагрузки.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        CalculationSheet ImportCalculationSheet(string path);
    }
}
