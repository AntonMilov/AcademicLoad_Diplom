using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademicLoadModule.Controllers.Interfaces;
using Core.Services.Interfaces;
using Microsoft.Win32;
using Prism.Services.Dialogs;


namespace AcademicLoadModule.Controllers
{
    /// <inheritdoc/>
    public class CalculationSheetController : ICalculationSheetController
    {
        private readonly OpenFileDialog openFileDialog;
        private readonly ICalculationSheetService calculationSheetService;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="openFileDialog"></param>
        public CalculationSheetController(OpenFileDialog openFileDialog, ICalculationSheetService calculationSheetService)
        {
            this.openFileDialog = openFileDialog;
            this.calculationSheetService = calculationSheetService;

        }

        public void AddCalculationSheet(string path)
        {
          calculationSheetService.AddCalculationSheet(path);
        }

        /// <inheritdoc/>
        public string AskExcelFile()
        {
            string path = string.Empty;
            string excelExtensions = "*.xls;*.xlsx";
            openFileDialog.Filter = $"XLS и XLSX-файлы ({excelExtensions})|{excelExtensions}";

            if (openFileDialog.ShowDialog() == true)
                return path = openFileDialog.FileName;

            return path;
        }
    }
}
