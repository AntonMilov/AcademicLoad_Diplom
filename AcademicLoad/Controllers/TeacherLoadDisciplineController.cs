using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademicLoadModule.Controllers.Interfaces;
using AcademicLoadModule.ViewModels;
using AcademicLoadModule.ViewModels.Add;
using AcademicLoadModule.Views.Add;
using Core.Services.Interfaces;
using Data.Models;
using Infrastructure.AddDialog;
using Infrastructure.NotificationDialog.Controller;
using Prism.Services.Dialogs;

namespace AcademicLoadModule.Controllers
{
    /// <inheritdoc cref="ITeacherLoadDisciplineController"/>
    public class TeacherLoadDisciplineController : ITeacherLoadDisciplineController
    {
        private readonly ITeacherLoadDisciplineService teacherLoadDisciplineService;
        private readonly INotificationDialogController notificationDialogController;
        private readonly IDialogService dialogService;
        private readonly ITeacherController teacherController;
        private readonly IGroupController groupController;

        /// <summary>
        /// ctor.
        /// </summary>
        public TeacherLoadDisciplineController(ITeacherLoadDisciplineService teacherLoadDisciplineService,
            INotificationDialogController notificationDialogController,
            IDialogService dialogService,
            ITeacherController teacherController,
            IGroupController groupController)
        {
            this.teacherLoadDisciplineService = teacherLoadDisciplineService;
            this.notificationDialogController = notificationDialogController;
            this.dialogService = dialogService;
            this.teacherController = teacherController;
            this.groupController = groupController;

            Items = this.teacherLoadDisciplineService.TeacherLoadDisciplines;
        }

        public void AddTeacherLoadDiscipline(CalculationSheetDiscipline calculationSheetDiscipline)
        {
            AddTeacherLoadDisciplineViewModel model = new AddTeacherLoadDisciplineViewModel(teacherController, 
                groupController,
                calculationSheetDiscipline);
            AddTeacherLoadDisciplineView view = new AddTeacherLoadDisciplineView() { DataContext = model };

            var addDialogParameters = new AddDialogParameters();
            addDialogParameters.CloseButtonText = Properties.Resources.Cancel;
            addDialogParameters.ConfirmButtonText = Properties.Resources.Add;
            addDialogParameters.Header = Properties.Resources.AddingTeacher;
            addDialogParameters.Title = Properties.Resources.AddingTeacher;
            addDialogParameters.Content = view;
            addDialogParameters.CanCloseWindow = model.CanAddTeacherLoadDiscipline;

            DialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add(nameof(AddDialogParameters), addDialogParameters);

            dialogService.Show("AddDialog", dialogParameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {

                    teacherLoadDisciplineService.AddTeacherLoadDiscipline(model.CreateTeacherLoadDiscipline(), calculationSheetDiscipline);
                }

                if (r.Result == ButtonResult.Cancel)
                {
                }
            });
        }

        public void DeleteTeacherLoadDiscipline(TeacherLoadDiscipline teacherLoadDiscipline,
            CalculationSheetDiscipline calculationSheetDiscipline)
        {
            teacherLoadDisciplineService.DeleteTeacherLoadDiscipline(teacherLoadDiscipline, calculationSheetDiscipline);
        }

        public List<TeacherLoadDiscipline> Items { get; set; }
    }
}
