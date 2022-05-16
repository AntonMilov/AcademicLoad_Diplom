using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademicLoadModule.Controllers.Interfaces;
using AcademicLoadModule.Events;
using AcademicLoadModule.ViewModels;
using AcademicLoadModule.ViewModels.Add;
using AcademicLoadModule.ViewModels.Edit;
using AcademicLoadModule.Views;
using AcademicLoadModule.Views.Add;
using AcademicLoadModule.Views.Edit;
using Core.Services.Interfaces;
using Data.Models;
using Infrastructure.AddDialog;
using Infrastructure.ConfirmDialog;
using Infrastructure.DialogControllers.Interfaces;
using Prism.Events;
using Prism.Services.Dialogs;

namespace AcademicLoadModule.Controllers
{
    /// <inheritdoc cref="IGroupController"/>
    public class GroupController : IGroupController
    {
        private readonly IDialogController dialogController;
        private readonly IEventAggregator eventAggregator;
        private readonly IGroupService groupService;
        private ObservableCollection<Group> items;

        /// <summary>
        /// ctor.
        /// </summary>
        public GroupController(IEventAggregator eventAggregator,
            IGroupService groupService,
            IDialogController dialogController)
        {
            this.eventAggregator = eventAggregator;
            this.groupService = groupService;
            this.dialogController = dialogController;

            items = new ObservableCollection<Group>(groupService.Groups);
        }

        /// <inheritdoc/>
        public ObservableCollection<Group> Items
        {
            get => items;
            set => items = value;
        }

        /// <inheritdoc/>
        public void AddGroup()
        {
            AddGroupViewModel model = new AddGroupViewModel();
            AddGroupView view = new AddGroupView() { DataContext = model };

            var addDialogParameters = new AddDialogParameters();
            addDialogParameters.CloseButtonText = Properties.Resources.Cancel;
            addDialogParameters.ConfirmButtonText = Properties.Resources.Add;
            addDialogParameters.Header = Properties.Resources.AddingGroup;
            addDialogParameters.Title = Properties.Resources.AddingGroup;
            addDialogParameters.Content = view;
            addDialogParameters.CanCloseWindow = model.CanAddGroup;

            dialogController.OpenAddDialog(addDialogParameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    Group group = model.CreateGroup();
                    items.Add(group);
                    groupService.AddGroup(group);

                    eventAggregator.GetEvent<GroupsCountChangeEvent>().Publish(Items.Count);

                    dialogController.OpenNotificationDialog(Properties.Resources.Notification, Properties.Resources.SuccessAddGroup);
                }

                if (r.Result == ButtonResult.Cancel)
                {
                }
            });
        }

        /// <inheritdoc/>
        public void DeleteGroup(Group group)
        {
            var confirmDialogParameters = new ConfirmDialogParameters();
            confirmDialogParameters.Message = Properties.Resources.MessageDeleteGroup;

            dialogController.OpenConfirmDialog(confirmDialogParameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    items.Remove(group);
                    groupService.DeleteGroup(group);

                    eventAggregator.GetEvent<GroupsCountChangeEvent>().Publish(Items.Count);

                    dialogController.OpenNotificationDialog(Properties.Resources.Notification, Properties.Resources.SuccessDeleteGroup);
                }
            });
        }

        /// <inheritdoc/>
        public void CheckGroupsCount()
        {
            eventAggregator.GetEvent<GroupsCountChangeEvent>().Publish(groupService.Groups.Count);
        }

        /// <inheritdoc/>
        public void EditGroup(Group group)
        {
            EditGroupViewModel model = new EditGroupViewModel(group);
            EditGroupView view = new EditGroupView() { DataContext = model };

            var addDialogParameters = new AddDialogParameters();
            addDialogParameters.CloseButtonText = Properties.Resources.Cancel;
            addDialogParameters.ConfirmButtonText = "Сохранить";
            addDialogParameters.Header = "Редактирование учебной группы";
            addDialogParameters.Title = "Редактирование учебной группы";
            addDialogParameters.Content = view;
            addDialogParameters.CanCloseWindow = model.CanAddGroup;

            dialogController.OpenAddDialog(addDialogParameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    Group editGroup = model.CreateGroup();
                    group.Name = editGroup.Name;
                    group.StudentsBudget = editGroup.StudentsBudget;
                    group.StudentsContract = editGroup.StudentsContract;

                    groupService.SaveEditGroup();

                    dialogController.OpenNotificationDialog(Properties.Resources.Notification, "Учебная группа успешно отредактирована");
                }

                if (r.Result == ButtonResult.Cancel)
                {
                }
            });
        }
    }
}
