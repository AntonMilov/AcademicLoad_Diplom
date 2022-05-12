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
    public class GroupsViewModel : BindableBase
    {
        private readonly IGroupController groupController;
        private ObservableCollection<Group> items;
        private Group selectedGroup;

        public GroupsViewModel(IGroupController groupController)
        {
            this.groupController = groupController;

            items = this.groupController.Items;
            AddGroupCommand = new DelegateCommand(AddGroup);
            DeleteGroupCommand = new DelegateCommand(DeleteGroup);
        }

        /// <summary>
        /// Учебные группы.
        /// </summary>
        public ObservableCollection<Group> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        /// <summary>
        /// Выбранная учебная группа.
        /// </summary>
        public Group SelectedGroup
        {
            get => selectedGroup;
            set => SetProperty(ref selectedGroup, value);
        }

        /// <summary>
        /// Команда для добавления учебной группы.
        /// </summary>
        public DelegateCommand AddGroupCommand { get; }

        /// <summary>
        /// Команда для удаления учебной группы
        /// </summary>
        public DelegateCommand DeleteGroupCommand { get; }

        private void AddGroup()
        {
            groupController.AddGroup();
        }

        private void DeleteGroup()
        {
            if (SelectedGroup != null)
            {
                groupController.DeleteGroup(SelectedGroup);
            }
        }
    }
}
