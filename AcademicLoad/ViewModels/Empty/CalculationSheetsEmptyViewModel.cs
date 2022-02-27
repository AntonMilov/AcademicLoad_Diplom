using AcademicLoadModule.Controllers.Interfaces;
using Prism.Commands;
using Prism.Mvvm;

namespace AcademicLoadModule.ViewModels.Empty
{
    public class CalculationSheetsEmptyViewModel : BindableBase
    {
        private readonly ICalculationSheetController calculationSheetController;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="calculationSheetController"></param>
        public CalculationSheetsEmptyViewModel(ICalculationSheetController calculationSheetController)
        {
            this.calculationSheetController = calculationSheetController;
            AddCalculationSheetCommand = new DelegateCommand(AddCalculationSheet);
        }

        /// <summary>
        /// Команда для добавления учебной группы.
        /// </summary>
        public DelegateCommand AddCalculationSheetCommand { get;  set; }

        private void AddCalculationSheet()
        {
            string path = calculationSheetController.AskExcelFile();
            calculationSheetController.AddCalculationSheet(path);
        }
    }
}
