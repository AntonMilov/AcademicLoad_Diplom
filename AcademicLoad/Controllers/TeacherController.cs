using AcademicLoadModule.Controllers.Interfaces;
using AcademicLoadModule.Views;
using Infrastructure.ConfirmDialog;
using Prism.Services.Dialogs;

namespace AcademicLoadModule.Controllers
{
    class TeacherController : ITeacherController
    {
        private IDialogService dialogService;

        public TeacherController(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }
        public void AddTeacher()
        {
            AddTeacherView view = new AddTeacherView();

            var confirmDialogParameters = new ConfirmDialogParameters();
            confirmDialogParameters.CloseButtonText = Properties.Resources.Cancel;
            confirmDialogParameters.ConfirmButtonText = Properties.Resources.Add;
            confirmDialogParameters.Header = Properties.Resources.AddingTeacher;
            confirmDialogParameters.Title = Properties.Resources.AddingTeacher;
            confirmDialogParameters.Content = new AddTeacherView();

            DialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add("confirmDialogParameters", confirmDialogParameters);

            //using the dialog service as-is
            dialogService.Show("ConfirmDialog", dialogParameters, r =>
            {
                if (r.Result == ButtonResult.None)
                {

                }
            });
        }
    }
}
