using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademicLoadModule.Controllers.Interfaces;
using AcademicLoadModule.Events;
using Core.Services.Interfaces;
using Data.Models;
using Infrastructure.DialogControllers.Interfaces;
using Microsoft.Win32;
using Prism.Events;
using Prism.Services.Dialogs;


namespace AcademicLoadModule.Controllers
{
    /// <inheritdoc/>
    public class CalculationSheetController : ICalculationSheetController
    {
        private readonly OpenFileDialog openFileDialog;
        private readonly SaveFileDialog saveFileDialog;
        private readonly ICalculationSheetService calculationSheetService;
        private readonly ITeacherLoadDisciplineService teacherLoadDisciplineService;
        private readonly ITeacherService teacherService;
        private readonly IEventAggregator eventAggregator;
        private readonly IDialogController dialogController;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="openFileDialog"></param>
        public CalculationSheetController(OpenFileDialog openFileDialog,
            SaveFileDialog saveFileDialog,
            ICalculationSheetService calculationSheetService,
            ITeacherLoadDisciplineService teacherLoadDisciplineService,
            ITeacherService teacherService,
            IEventAggregator eventAggregator,
            IDialogController dialogController)
        {
            this.openFileDialog = openFileDialog;
            this.saveFileDialog = saveFileDialog;
            this.calculationSheetService = calculationSheetService;
            this.teacherService = teacherService;
            this.teacherLoadDisciplineService = teacherLoadDisciplineService;
            this.eventAggregator = eventAggregator;
            this.dialogController = dialogController;
        }

        /// <inheritdoc/>
        public CalculationSheet CalculationSheet { get; set; }

        /// <inheritdoc/>
        public void AddCalculationSheet(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            try
            {
                CalculationSheet = calculationSheetService.AddCalculationSheet(path);
                eventAggregator.GetEvent<CalculationSheetAddedEvent>().Publish();
            }
            catch (Exception e)
            {
                dialogController.OpenNotificationDialog(Properties.Resources.Notification, "Не удалось импортировать данный файл.");
            }
        }

        /// <inheritdoc/>
        public string AskExportExcelFile()
        {
            string path = string.Empty;
            string xlsxExtensions = "(*.xlsx)|*.xlsx";

            saveFileDialog.Filter = $"XLSX файл{xlsxExtensions}";

            if (saveFileDialog.ShowDialog() == true)
                return path = saveFileDialog.FileName;

            return path;
        }

        /// <inheritdoc/>
        public string AskImportExcelFile()
        {
            string path = string.Empty;
            string excelExtensions = "*.xlsx;";
            openFileDialog.Filter = $"XLSX-файлы ({excelExtensions})|{excelExtensions}";

            if (openFileDialog.ShowDialog() == true)
                return path = openFileDialog.FileName;

            return path;
        }

        /// <inheritdoc/>
        public void ExportTeacherLoad(string path)
        {
            teacherLoadDisciplineService.ExportTeacherLoadDisciplines(path, CalculationSheet, teacherService.Teachers);
        }
    }
}
