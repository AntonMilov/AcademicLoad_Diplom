using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
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
        private ICollectionView items;
        private Teacher selectedTeacher;
        private string searchFilter;

        /// <summary>
        /// .ctor
        /// </summary>
        public TeachersViewModel(ITeacherController teacherController)
        {
            this.teacherController = teacherController;
            AddTeacherCommand = new DelegateCommand(AddTeacher);
            DeleteTeacherCommand = new DelegateCommand(DeleteTeacher);
            Items = CollectionViewSource.GetDefaultView(teacherController.Items);
        }

        /// <summary>
        /// Преподаватели.
        /// </summary>
        public ICollectionView Items
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

        /// <summary>
        /// Фильтр поиска.
        /// </summary>
        public string SearchFilter
        {
            get => searchFilter;
            set
            {
                SetProperty(ref searchFilter, value.ToLower());

                Predicate<object> filter = new Predicate<object>(x => Filter((Teacher)x));
                Items.Filter = filter;
            }
        }

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

        private bool Filter(Teacher teacher) 
        {
            if ( teacher.FirstName.ToLower().Contains(SearchFilter))
            {
                return true;
            }
            if (teacher.LastName.ToLower().Contains(SearchFilter))
            {
                return true;
            }
            if (teacher.MiddleName.ToLower().Contains(SearchFilter))
            {
                return true;
            }

            return false;
        }
    }
}
