using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using AcademicLoadModule.Controllers.Interfaces;
using AcademicLoadModule.Events;
using Data.Models;
using Prism.Events;

namespace AcademicLoadModule.ViewModels
{
  
    public class CalculationSheetViewModel : BindableBase
    {
        private CalculationSheet calculationSheet;
        private readonly ICalculationSheetController calculationSheetController;

        /// <summary>
        /// ctor.
        /// </summary>
        public CalculationSheetViewModel(ICalculationSheetController calculationSheetController,IEventAggregator eventAggregator)
        {
           this.calculationSheetController = calculationSheetController;
            CalculationSheet = calculationSheetController.CalculationSheet;
            eventAggregator.GetEvent<CalculationSheetAddedEvent>().Subscribe(CalculationSheetAddedHandler);
        }
      

        /// <summary>
        /// Расчетный лист кафедральной нагрузки
        /// </summary>
        public CalculationSheet CalculationSheet
        {
            get => calculationSheet;
            set => SetProperty(ref calculationSheet, value);
        }

        private void CalculationSheetAddedHandler()
        {
            CalculationSheet = calculationSheetController.CalculationSheet;
        }
    }
}
