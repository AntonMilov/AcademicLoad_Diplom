using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Excel.Interfaces;
using Core.Services.Interfaces;
using Data.Models;

namespace Core.Services
{
    /// <summary>
    /// <see cref="ICalculationSheetService"/>
    /// </summary>
    public class CalculationSheetService : ICalculationSheetService
    {
        private readonly IExcelImporter excelExporter;

        /// <summary>
        /// .ctor
        /// </summary>
        public CalculationSheetService(IExcelImporter excelExporter)
        {
            this.excelExporter = excelExporter;
        }

        /// <inheritdoc/>
        public CalculationSheet AddCalculationSheet(string path)
        {
            return excelExporter.ImportCalculationSheet(path);
        }
    }
}
