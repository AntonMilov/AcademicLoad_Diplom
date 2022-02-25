using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using AcademicLoadModule.Controllers.Interfaces;

namespace AcademicLoadModule.ViewModels
{
    public class GroupsEmptyViewModel : BindableBase
    {
        private readonly IGroupController groupController;

        /// <summary>
        /// ctor.
        /// </summary>
        public GroupsEmptyViewModel(IGroupController groupController)
        {
            this.groupController = groupController;
            AddGroupCommand = new DelegateCommand(addGroup);
        }

        /// <summary>
        /// Команда для добавления учебной группы.
        /// </summary>
        public DelegateCommand AddGroupCommand { get; private set; }

        private void addGroup()
        {
            groupController.AddGroup();
        }
    }
}
