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
using Infrastructure.ConfirmDialog;
using Infrastructure.DialogControllers.Interfaces;
using Prism.Services.Dialogs;

namespace AcademicLoadModule.Controllers
{
    /// <inheritdoc cref="ITeacherLoadDisciplineController"/>
    public class TeacherLoadDisciplineController : ITeacherLoadDisciplineController
    {
        private readonly ITeacherLoadDisciplineService teacherLoadDisciplineService;
        private readonly IDialogController dialogController;
        private readonly ITeacherController teacherController;
        private readonly IGroupController groupController;

        /// <summary>
        /// ctor.
        /// </summary>
        public TeacherLoadDisciplineController(ITeacherLoadDisciplineService teacherLoadDisciplineService,
            ITeacherController teacherController,
            IGroupController groupController,
            IDialogController dialogController)
        {
            this.teacherLoadDisciplineService = teacherLoadDisciplineService;
            this.dialogController = dialogController;
            this.teacherController = teacherController;
            this.groupController = groupController;

            Items = this.teacherLoadDisciplineService.TeacherLoadDisciplines;
        }

        /// <inheritdoc/>
        public void AddTeacherLoadDiscipline(CalculationSheetDiscipline calculationSheetDiscipline)
        {
            AddTeacherLoadDisciplineViewModel model = new AddTeacherLoadDisciplineViewModel(teacherController,
                groupController,
                calculationSheetDiscipline);
            AddTeacherLoadDisciplineView view = new AddTeacherLoadDisciplineView() { DataContext = model };

            var addDialogParameters = new AddDialogParameters();
            addDialogParameters.CloseButtonText = Properties.Resources.Cancel;
            addDialogParameters.ConfirmButtonText = Properties.Resources.Add;
            addDialogParameters.Header = "Назначение преподавателя";
            addDialogParameters.Title = "Назначение преподавателя";
            addDialogParameters.Content = view;
            addDialogParameters.CanCloseWindow = model.CanAddTeacherLoadDiscipline;

            dialogController.OpenAddDialog(addDialogParameters, r =>
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

        /// <inheritdoc/>
        public void DeleteTeacherLoadDiscipline(TeacherLoadDiscipline teacherLoadDiscipline,
            CalculationSheetDiscipline calculationSheetDiscipline)
        {
            var confirmDialogParameters = new ConfirmDialogParameters();
            confirmDialogParameters.Message = Properties.Resources.MessageDeleteTeacherLoadDiscipline;

            dialogController.OpenConfirmDialog(confirmDialogParameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    teacherLoadDisciplineService.DeleteTeacherLoadDiscipline(teacherLoadDiscipline, calculationSheetDiscipline);
                    dialogController.OpenNotificationDialog(Properties.Resources.Notification, Properties.Resources.SuccessDeleteTeacherLoadDiscipline);
                }
            });
        }

        /// <inheritdoc/>
        public List<TeacherLoadDiscipline> Items { get; set; }
    }
}
