using System.Collections.ObjectModel;
using AcademicLoadModule.Controllers.Interfaces;
using Data.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace AcademicLoadModule.ViewModels
{
    /// <inheritdoc/>
    public class TeachersViewModel : BindableBase
    {
        private readonly ITeacherController teacherController;
        private ObservableCollection<Teacher> items;
        private Teacher selectedTeacher;

        /// <summary>
        /// .ctor
        /// </summary>
        public TeachersViewModel(ITeacherController teacherController)
        {
            this.teacherController = teacherController;
            AddTeacherCommand = new DelegateCommand(AddTeacher);
            DeleteTeacherCommand = new DelegateCommand(DeleteTeacher);
            Items = teacherController.Items;
        }

        /// <summary>
        /// Преподаватели.
        /// </summary>
        public ObservableCollection<Teacher> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        /// <summary>
        /// Выбранная учебная группа.
        /// </summary>
        public Teacher SelectedTeacher
        {
            get => selectedTeacher;
            set => SetProperty(ref selectedTeacher, value);
        }

        /// <summary>
        /// Команда для добавения преподавателя.
        /// </summary>
        public DelegateCommand AddTeacherCommand { get; }

        /// <summary>
        /// Команда для удаления преподавателя.
        /// </summary>
        public DelegateCommand DeleteTeacherCommand { get; }

        private void AddTeacher()
        {
            teacherController.AddTeacher();
        }

        private void DeleteTeacher()
        {
            if (SelectedTeacher != null)
            {
                teacherController.DeleteTeacher(SelectedTeacher);
            }
        }

    }

}
