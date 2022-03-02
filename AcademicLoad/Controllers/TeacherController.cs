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
        /// <param name="dialogService"></param>
        /// <param name="eventAggregator"></param>
        /// <param name="teacherService"></param>
        /// <param name="notificationDialogController"></param>
        public TeacherController(IDialogService dialogService, IEventAggregator eventAggregator, ITeacherService teacherService, INotificationDialogController notificationDialogController)
        {
            this.notificationDialogController = notificationDialogController;
            this.dialogService = dialogService;
            this.eventAggregator = eventAggregator;
            this.teacherService = teacherService;

            items = new ObservableCollection<Teacher>(teacherService.Teachers);
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
         
            dialogService.Show("ConfirmDialog", dialogParameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    items.Add(model.CreateTeacher());
                    teacherService.AddTeacher(model.CreateTeacher());

                    eventAggregator.GetEvent<TeachersCountChangeEvent>().Publish(teacherService.Teachers.Count);

                    notificationDialogController.OpenNotificationDialog(Properties.Resources.Notification, Properties.Resources.SuccessAddTeahcer);
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

        public ObservableCollection<Teacher> Items
        {
            get => items;
            set => items = value;
        }

    }
}
