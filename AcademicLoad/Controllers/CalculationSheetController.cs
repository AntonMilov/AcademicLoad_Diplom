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
            string pfxExtensions = "*.pfx";
            openFileDialog.Filter = $"PFX-файлы ({pfxExtensions})|{pfxExtensions}";

            openFileDialog.ShowDialog();
            
            string path = openFileDialog.FileName;

            return path;
        }
    }
}
