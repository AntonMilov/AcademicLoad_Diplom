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
        private readonly IExcelExporter excelExporter;

        /// <summary>
        /// .ctor
        /// </summary>
        public CalculationSheetService(IExcelExporter excelExporter)
        {
            this.excelExporter = excelExporter;
           
        }

        /// <inheritdoc/>
        public CalculationSheet AddCalculationSheet(string path)
        {
            return excelExporter.ExportCalculationSheet(path);
        }
    }
}
