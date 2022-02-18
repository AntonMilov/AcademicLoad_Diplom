using AcademicLoadModule.Controllers.Interfaces;
using AcademicLoadModule.Views;
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
            AddTeacherView a = new AddTeacherView();
            DialogParameters b = new DialogParameters();
            b.Add("Content", a);

            //using the dialog service as-is
            dialogService.Show("ConfirmDialog", b, r =>
            {
                if (r.Result == ButtonResult.None)
                {

                }
            });
        }
    }
}
