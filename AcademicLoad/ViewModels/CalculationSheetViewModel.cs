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
        private readonly ITeacherLoadDisciplineController teacherLoadDisciplineController;
        private CalculationSheetDiscipline selectedCalculationSheetDiscipline;

        /// <summary>
        /// ctor.
        /// </summary>
        public CalculationSheetViewModel(ICalculationSheetController calculationSheetController, IEventAggregator eventAggregator,
            IGroupController groupController,
            ITeacherController teacherController,
            ITeacherLoadDisciplineController teacherLoadDisciplineController)
        {
            this.calculationSheetController = calculationSheetController;
            this.teacherLoadDisciplineController = teacherLoadDisciplineController;

            CalculationSheet = calculationSheetController.CalculationSheet;
            eventAggregator.GetEvent<CalculationSheetAddedEvent>().Subscribe(CalculationSheetAddedHandler);

            //TODO Рефакторить
            groupController.CheckGroupsCount();
            teacherController.CheckTeacherCount();
        }

        /// <summary>
        /// Команда для дисциплины учебной нагрузки.
        /// </summary>
        public DelegateCommand<CalculationSheetDiscipline> AddTeacherLoadDisciplineCommand => new DelegateCommand<CalculationSheetDiscipline>(AddTeacherLoadDiscipline);


        /// <summary>
        /// Расчетный лист кафедральной нагрузки
        /// </summary>
        public CalculationSheet CalculationSheet
        {
            get => calculationSheet;
            set => SetProperty(ref calculationSheet, value);
        }

        /// <summary>
        /// Выбранная дисциплина
        /// </summary>
        public CalculationSheetDiscipline SelectedCalculationSheetDiscipline
        {
            get => selectedCalculationSheetDiscipline;
            set => SetProperty(ref selectedCalculationSheetDiscipline, value);
        }

        private void CalculationSheetAddedHandler()
        {
            CalculationSheet = calculationSheetController.CalculationSheet;
        }

        private void AddTeacherLoadDiscipline(CalculationSheetDiscipline calculationSheetDiscipline)
        {
            teacherLoadDisciplineController.AddTeacherLoadDiscipline(calculationSheetDiscipline);
        }
    }
}
