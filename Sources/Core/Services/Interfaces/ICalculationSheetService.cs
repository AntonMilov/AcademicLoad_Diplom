using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Core.Services.Interfaces
{
    /// <summary>
    /// Интерфейс для сервиса расчетных листов кафедральной нагрузки.
    /// </summary>
    public interface ICalculationSheetService
    {
        /// <summary>
        /// Добавить расчетный лист кафедральной нагрузки.
        /// </summary>
        CalculationSheet AddCalculationSheet(string path);

    }
}
