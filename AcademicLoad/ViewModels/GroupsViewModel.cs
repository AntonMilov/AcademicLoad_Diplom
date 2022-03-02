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

        public GroupsViewModel(IGroupController groupController)
        {
            this.groupController = groupController;
            items = this.groupController.Items;
            AddGroupCommand = new DelegateCommand(AddGroup);
        }

        public ObservableCollection<Group> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        /// <summary>
        /// Команда для добавления учебной группы.
        /// </summary>
        public DelegateCommand AddGroupCommand { get; private set; }

        private void AddGroup()
        {
            groupController.AddGroup();
        }
    }
}
