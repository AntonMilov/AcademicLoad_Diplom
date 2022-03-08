using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using AcademicLoadModule.Controllers.Interfaces;
using AcademicLoadModule.Events;
using AcademicLoadModule.ViewModels;
using AcademicLoadModule.ViewModels.Add;
using AcademicLoadModule.Views;
using AcademicLoadModule.Views.Add;
using Core.Services.Interfaces;
using Data.Models;
using Infrastructure.AddDialog;
using Infrastructure.ConfirmDialog;
using Infrastructure.DialogControllers.Interfaces;
using Prism.Events;
using Prism.Services.Dialogs;

namespace AcademicLoadModule.Controllers
{
    /// <summary>
    /// <inheritdoc cref="ITeacherController"/>
    /// </summary>
    public class TeacherController : ITeacherController
    {
        private readonly IDialogController dialogController;
        private readonly IEventAggregator eventAggregator;
        private readonly ITeacherService teacherService;
        private ObservableCollection<Teacher> items;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="dialogService">.</param>
        /// <param name="eventAggregator">.</param>
        /// <param name="teacherService">.</param>
        /// <param name="notificationDialogController">.</param>
        public TeacherController(IEventAggregator eventAggregator,
            ITeacherService teacherService,
            IDialogController dialogController)
        {
            this.dialogController = dialogController;
            this.eventAggregator = eventAggregator;
            this.teacherService = teacherService;

            items = new ObservableCollection<Teacher>(teacherService.Teachers);
        }

        /// <inheritdoc/>
        public ObservableCollection<Teacher> Items
        {
            get => items;
            set => items = value;
        }

        /// <inheritdoc/>
        public void AddTeacher()
        {
            AddTeacherViewModel model = new AddTeacherViewModel();
            AddTeacherView view = new AddTeacherView() { DataContext = model };

            var addDialogParameters = new AddDialogParameters();
            addDialogParameters.CloseButtonText = Properties.Resources.Cancel;
            addDialogParameters.ConfirmButtonText = Properties.Resources.Add;
            addDialogParameters.Header = Properties.Resources.AddingTeacher;
            addDialogParameters.Title = Properties.Resources.AddingTeacher;
            addDialogParameters.Content = view;
            addDialogParameters.CanCloseWindow = model.CanAddTeacher;

            dialogController.OpenAddDialog(addDialogParameters, r =>
             {
                 if (r.Result == ButtonResult.OK)
                 {
                     items.Add(model.CreateTeacher());
                     teacherService.AddTeacher(model.CreateTeacher());

                     eventAggregator.GetEvent<TeachersCountChangeEvent>().Publish(teacherService.Teachers.Count);

                     dialogController.OpenNotificationDialog(Properties.Resources.Notification, Properties.Resources.SuccessAddTeacher);
                 }

                 if (r.Result == ButtonResult.Cancel)
                 {

                 }
             });
        }

        /// <inheritdoc/>
        public void DeleteTeacher(Teacher teacher)
        {
            var confirmDialogParameters = new ConfirmDialogParameters();
            confirmDialogParameters.Message = Properties.Resources.MessageDeleteTeacher;

            dialogController.OpenConfirmDialog(confirmDialogParameters, r =>
             {
                 if (r.Result == ButtonResult.OK)
                 {
                     items.Remove(teacher);
                     teacherService.DeleteTeacher(teacher);

                     eventAggregator.GetEvent<TeachersCountChangeEvent>().Publish(Items.Count);

                     dialogController.OpenNotificationDialog(Properties.Resources.Notification, Properties.Resources.SuccessDeleteTeacher);
                 }

                 if (r.Result == ButtonResult.Cancel)
                 {

                 }
             });
        }

        /// <inheritdoc/>
        public void CheckTeacherCount()
        {
            eventAggregator.GetEvent<TeachersCountChangeEvent>().Publish(teacherService.Teachers.Count);
        }
    }
}
