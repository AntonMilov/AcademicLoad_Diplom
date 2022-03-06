using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AcademicLoadModule.Controllers.Interfaces;
using Data.Models;

namespace AcademicLoadModule.ViewModels
{
    public class AddTeacherLoadDisciplineViewModel : BindableBase
    {
        private Teacher selectedTeacher;
        private ObservableCollection<Teacher> teachers;
        private Group selectedGroup;
        private ObservableCollection<Group> groups;
        private ObservableCollection<Group> selectedGroups;
        private bool showAddTeacherButton = true;
        private bool isMainLecture;

        /// <summary>
        /// ctor.
        /// </summary>
        public AddTeacherLoadDisciplineViewModel(ITeacherController teacherController,
            IGroupController groupController)
        {
            Teachers = teacherController.Items;
            Groups = new ObservableCollection<Group>(groupController.Items);
            SelectedGroups = new ObservableCollection<Group>();
        }

        /// <summary>
        /// Учебные группы.
        /// </summary>
        public ObservableCollection<Group> Groups
        {
            get => groups;
            set => SetProperty(ref groups, value);
        }

        /// <summary>
        /// Выбранные учебные группы.
        /// </summary>
        public ObservableCollection<Group> SelectedGroups
        {
            get => selectedGroups;
            set => SetProperty(ref selectedGroups, value);
        }

        /// <summary>
        /// Выбанная учебная группа.
        /// </summary>
        public Group SelectedGroup
        {
            get => selectedGroup;
            set
            {
                SetProperty(ref selectedGroup, value);
                if (value != null)
                {
                    SelectedGroups.Add(selectedGroup);
                    Groups.Remove(selectedGroup);
                }
            }
        }

        /// <summary>
        /// Преподователи.
        /// </summary>
        public ObservableCollection<Teacher> Teachers
        {
            get => teachers;
            set => SetProperty(ref teachers, value);
        }

        /// <summary>
        /// Выбранный преподователь.
        /// </summary>
        public Teacher SelectedTeacher
        {
            get => selectedTeacher;
            set
            {
                if (value != null)
                {
                    ShowAddTeacherButton = false;
                    SetProperty(ref selectedTeacher, value);

                }

                if (value == null)
                {
                    ShowAddTeacherButton = true;
                    SetProperty(ref selectedTeacher, value);
                }

            }
        }

        /// <summary>
        /// Показывать ли кнопку добавления учителя.
        /// </summary>
        public bool ShowAddTeacherButton
        {
            get => showAddTeacherButton;
            set => SetProperty(ref showAddTeacherButton, value);
        }

        /// <summary>
        /// Является ли преподаватель основным лектором.
        /// </summary>
        public bool IsMainLecture
        {
            get => isMainLecture;
            set => SetProperty(ref isMainLecture, value);
        }

        /// <summary>
        /// Команда для удаления преподавателя
        /// </summary>
        public DelegateCommand DeleteTeacherCommand => new DelegateCommand(DeleteTeacher);

        /// <summary>
        /// Команда для удаления учебной группы
        /// </summary>
        public DelegateCommand<Group> DeleteGroupCommand => new DelegateCommand<Group>(DeleteGroup);
      
        ///<summary>
        /// Проверка на заполнение всех полей.
        /// </summary>
        public bool CanAddTeacherLoadDiscipline()
        {
            return SelectedTeacher != null &&
                   SelectedGroups.Any();
        }

        private void DeleteTeacher()
        {
            SelectedTeacher = null;
        }

        private void DeleteGroup(Group group)
        {
            SelectedGroups.Remove(group);
            Groups.Add(group);
        }
    }
}
