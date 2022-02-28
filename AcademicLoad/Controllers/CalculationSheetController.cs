using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademicLoadModule.Controllers.Interfaces;
using AcademicLoadModule.Events;
using Core.Services.Interfaces;
using Data.Models;
using Microsoft.Win32;
using Prism.Events;
using Prism.Services.Dialogs;


namespace AcademicLoadModule.Controllers
{
    /// <inheritdoc/>
    public class CalculationSheetController : ICalculationSheetController
    {
        private readonly OpenFileDialog openFileDialog;
        private readonly ICalculationSheetService calculationSheetService;
        private readonly IEventAggregator eventAggregator;
        private CalculationSheet calculationSheet;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="openFileDialog"></param>
        public CalculationSheetController(OpenFileDialog openFileDialog, 
            ICalculationSheetService calculationSheetService, 
            IEventAggregator eventAggregator)
        {
            this.openFileDialog = openFileDialog;
            this.calculationSheetService = calculationSheetService;
            this.eventAggregator = eventAggregator;

        }

        public CalculationSheet CalculationSheet { get; set; }

        public void AddCalculationSheet(string path)
        {
            CalculationSheet=calculationSheetService.AddCalculationSheet(path);
            eventAggregator.GetEvent<CalculationSheetAddedEvent>().Publish();
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
