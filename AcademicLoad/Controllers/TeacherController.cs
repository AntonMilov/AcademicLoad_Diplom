using System.Diagnostics;
using AcademicLoadModule.Controllers.Interfaces;
using AcademicLoadModule.Events;
using AcademicLoadModule.Views;
using Core.Services.Interfaces;
using Data.Models;
using Infrastructure.ConfirmDialog;
using Prism.Events;
using Prism.Services.Dialogs;

namespace AcademicLoadModule.Controllers
{
    class TeacherController : ITeacherController
    {
        private IDialogService dialogService;
        private readonly IEventAggregator eventAggregator;
        private readonly ITeacherService teacherService;


        public TeacherController(IDialogService dialogService, IEventAggregator eventAggregator, ITeacherService teacherService)
        {
            this.dialogService = dialogService;
            this.eventAggregator = eventAggregator;
            this.teacherService = teacherService;
        }
        public void AddTeacher()
        {
            AddTeacherView view = new AddTeacherView();

            var confirmDialogParameters = new ConfirmDialogParameters();
            confirmDialogParameters.CloseButtonText = Properties.Resources.Cancel;
            confirmDialogParameters.ConfirmButtonText = Properties.Resources.Add;
            confirmDialogParameters.Header = Properties.Resources.AddingTeacher;
            confirmDialogParameters.Title = Properties.Resources.AddingTeacher;
            confirmDialogParameters.Content = view;

            DialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add("confirmDialogParameters", confirmDialogParameters);
            //using the dialog service as-is
            dialogService.Show("ConfirmDialog", dialogParameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    Debug.WriteLine("hui");
                }
                if (r.Result == ButtonResult.Cancel)
                {
                    Debug.WriteLine("hui1");
                }
            });

            teacherService.AddTeacher(new Teacher());
            eventAggregator.GetEvent<TeachersCountChangeEvent>().Publish(teacherService.Teachers.Count);
        }
    }
}
