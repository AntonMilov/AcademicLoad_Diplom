using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AcademicLoadModule.Controllers.Interfaces;
using Data.Models;
using System.ComponentModel;
using System.Windows.Data;

namespace AcademicLoadModule.ViewModels
{
    /// <summary>
    /// VM для учебных групп.
    /// </summary>
    public class GroupsViewModel : BindableBase
    {
        private readonly IGroupController groupController;
        private ICollectionView items;
        private Group selectedGroup;
        private string searchFilter;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="groupController"><see cref="IGroupController"/>.</param>
        public GroupsViewModel(IGroupController groupController)
        {
            this.groupController = groupController;

            items = CollectionViewSource.GetDefaultView(groupController.Items);
            AddGroupCommand = new DelegateCommand(AddGroup);
            DeleteGroupCommand = new DelegateCommand(DeleteGroup);
            EditGroupCommand = new DelegateCommand(EditGroup);
        }

        /// <summary>
        /// Учебные группы.
        /// </summary>
        public ICollectionView Items
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
        /// Фильтр поиска.
        /// </summary>
        public string SearchFilter
        {
            get => searchFilter;
            set
            {
                SetProperty(ref searchFilter, value.ToLower());
                Predicate<object> filter = new Predicate<object>(x => Filter((Group)x));
                Items.Filter = filter;
            }
        }

        /// <summary>
        /// Команда для добавления учебной группы.
        /// </summary>
        public DelegateCommand AddGroupCommand { get; }

        /// <summary>
        /// Команда для удаления учебной группы.
        /// </summary>
        public DelegateCommand DeleteGroupCommand { get; }

        /// <summary>
        /// Редактирование учебной группы.
        /// </summary>
        public DelegateCommand EditGroupCommand { get; }

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

        private void EditGroup()
        {
            if (SelectedGroup != null)
            {
                groupController.EditGroup(SelectedGroup);
            }
        }

        private bool Filter(Group group)
        {
            if (group.Name.ToLower().Contains(SearchFilter))
            {
                return true;
            }

            return false;
        }
    }
}
