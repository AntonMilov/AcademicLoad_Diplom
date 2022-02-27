using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademicLoadModule.Controllers.Interfaces;
using Microsoft.Win32;
using Prism.Services.Dialogs;


namespace AcademicLoadModule.Controllers
{
    /// <inheritdoc/>
    public class CalculationSheetController : ICalculationSheetController
    {
        private readonly OpenFileDialog openFileDialog;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="openFileDialog"></param>
        public CalculationSheetController(OpenFileDialog openFileDialog)
        {
            this.openFileDialog = openFileDialog;

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
