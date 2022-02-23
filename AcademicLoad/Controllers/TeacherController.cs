using System.Diagnostics;
using AcademicLoadModule.Controllers.Interfaces;
using AcademicLoadModule.Events;
using AcademicLoadModule.ViewModels;
using AcademicLoadModule.Views;
using Core.Services.Interfaces;
using Data.Models;
using Infrastructure.ConfirmDialog;
using Infrastructure.NotificationDialog.Controller;
using Prism.Events;
using Prism.Services.Dialogs;

namespace AcademicLoadModule.Controllers
{
    class TeacherController : ITeacherController
    {
        private readonly INotificationDialogController notificationDialogController;
        private IDialogService dialogService;
        private readonly IEventAggregator eventAggregator;
        private readonly ITeacherService teacherService;


        public TeacherController(IDialogService dialogService, IEventAggregator eventAggregator, ITeacherService teacherService, INotificationDialogController notificationDialogController)
        {
            this.notificationDialogController = notificationDialogController;
            this.dialogService = dialogService;
            this.eventAggregator = eventAggregator;
            this.teacherService = teacherService;
        }
        public void AddTeacher()
        {
            AddTeacherViewModel model = new AddTeacherViewModel();
            AddTeacherView view = new AddTeacherView(){DataContext = model};

            var confirmDialogParameters = new ConfirmDialogParameters();
            confirmDialogParameters.CloseButtonText = Properties.Resources.Cancel;
            confirmDialogParameters.ConfirmButtonText = Properties.Resources.Add;
            confirmDialogParameters.Header = Properties.Resources.AddingTeacher;
            confirmDialogParameters.Title = Properties.Resources.AddingTeacher;
            confirmDialogParameters.Content = view;
            confirmDialogParameters.CanCloseWindow = model.CanAddTeacher;

            DialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add("confirmDialogParameters", confirmDialogParameters);
            //using the dialog service as-is
            dialogService.Show("ConfirmDialog", dialogParameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    teacherService.AddTeacher(model.CreateTeacher());
                    eventAggregator.GetEvent<TeachersCountChangeEvent>().Publish(teacherService.Teachers.Count);
                    notificationDialogController.OpenNotificationDialog(Properties.Resources.Notification, Properties.Resources.SuccessAddTeahcer);
                }
                if (r.Result == ButtonResult.Cancel)
                {
                  
                }
            });
        }
    }
}
