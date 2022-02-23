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

        /// <summary>
        /// .ctor
        /// </summary>
        public TeachersViewModel(ITeacherController teacherController)
        {
            this.teacherController = teacherController;
            AddTeacherCommand = new DelegateCommand(addTeacher);
            Items = teacherController.Items;


        }

        private ObservableCollection<Teacher> items;


        public ObservableCollection<Teacher> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        /// <summary>
        /// Команда для добавения преподавателя.
        /// </summary>
        public DelegateCommand AddTeacherCommand { get; private set; }

        private void addTeacher()
        {
            teacherController.AddTeacher();
        }

    }

}
