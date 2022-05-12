using AcademicLoadModule.Controllers.Interfaces;
using Prism.Commands;
using Prism.Mvvm;

namespace AcademicLoadModule.ViewModels.Empty
{
    /// <summary>
    /// 
    /// </summary>
    public class TeachersEmptyViewModel : BindableBase
    {
        private readonly ITeacherController teacherController;

        /// <summary>
        /// .ctor
        /// </summary>
        public TeachersEmptyViewModel(ITeacherController teacherController)
        {
            this.teacherController = teacherController;
            AddTeacherCommand = new DelegateCommand(AddTeacher);
        }

        /// <summary>
        /// Команда для добавления преподавателя.
        /// </summary>
        public DelegateCommand AddTeacherCommand { get; private set; }

        private void AddTeacher()
        {
            teacherController.AddTeacher();
        }
    }
}
