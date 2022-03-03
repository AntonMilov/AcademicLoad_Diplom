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
using Infrastructure.NotificationDialog.Controller;
using Prism.Events;
using Prism.Services.Dialogs;

namespace AcademicLoadModule.Controllers
{
    public class TeacherController : ITeacherController
    {
        private readonly INotificationDialogController notificationDialogController;
        private readonly IDialogService dialogService;
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
        public TeacherController(IDialogService dialogService, IEventAggregator eventAggregator, ITeacherService teacherService, INotificationDialogController notificationDialogController)
        {
            this.notificationDialogController = notificationDialogController;
            this.dialogService = dialogService;
            this.eventAggregator = eventAggregator;
            this.teacherService = teacherService;

            items = new ObservableCollection<Teacher>(teacherService.Teachers);
        }

        public ObservableCollection<Teacher> Items
        {
            get => items;
            set => items = value;
        }

        public void AddTeacher()
        {
            AddTeacherViewModel model = new AddTeacherViewModel();
            AddTeacherView view = new AddTeacherView(){DataContext = model};

            var addDialogParameters = new AddDialogParameters();
            addDialogParameters.CloseButtonText = Properties.Resources.Cancel;
            addDialogParameters.ConfirmButtonText = Properties.Resources.Add;
            addDialogParameters.Header = Properties.Resources.AddingTeacher;
            addDialogParameters.Title = Properties.Resources.AddingTeacher;
            addDialogParameters.Content = view;
            addDialogParameters.CanCloseWindow = model.CanAddTeacher;

            DialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add(nameof(AddDialogParameters), addDialogParameters);
         
            dialogService.Show("AddDialog", dialogParameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    items.Add(model.CreateTeacher());
                    teacherService.AddTeacher(model.CreateTeacher());

                    eventAggregator.GetEvent<TeachersCountChangeEvent>().Publish(teacherService.Teachers.Count);

                    notificationDialogController.OpenNotificationDialog(Properties.Resources.Notification, Properties.Resources.SuccessAddTeacher);
                }

                if (r.Result == ButtonResult.Cancel)
                {
                  
                }
            });
        }

        public void DeleteTeacher(Teacher teacher)
        {
            var confirmDialogParameters = new ConfirmDialogParameters();
            confirmDialogParameters.Message = Properties.Resources.MessageDeleteTeacher;

            DialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add(nameof(ConfirmDialogParameters), confirmDialogParameters);
            dialogService.Show("ConfirmDialog", dialogParameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    items.Remove(teacher);
                    teacherService.DeleteTeacher(teacher);

                    eventAggregator.GetEvent<TeachersCountChangeEvent>().Publish(Items.Count);

                    notificationDialogController.OpenNotificationDialog(Properties.Resources.Notification,
                        Properties.Resources.SuccessDeleteTeacher);
                }

                if (r.Result == ButtonResult.Cancel)
                {

                }
            });
        }

        public void CheckTeacherCount()
        {
            eventAggregator.GetEvent<TeachersCountChangeEvent>().Publish(teacherService.Teachers.Count);
        }

       
    }
}
