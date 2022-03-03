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
using AcademicLoadModule.Views;
using AcademicLoadModule.Views.Add;
using Core.Services.Interfaces;
using Data.Models;
using Infrastructure.AddDialog;
using Infrastructure.ConfirmDialog;
using Infrastructure.NotificationDialog.Controller;
using Prism.Events;
using Prism.Services.Dialogs;

namespace AcademicLoadModule.Controllers
{
    /// <inheritdoc cref="IGroupController"/>
    public class GroupController : IGroupController
    {
        private readonly INotificationDialogController notificationDialogController;
        private readonly IDialogService dialogService;
        private readonly IEventAggregator eventAggregator;
        private readonly IGroupService groupService;
        private ObservableCollection<Group> items;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="dialogService"></param>
        /// <param name="eventAggregator"></param>
        /// <param name="teacherService"></param>
        /// <param name="notificationDialogController"></param>
        public GroupController(IDialogService dialogService,
            IEventAggregator eventAggregator,
            IGroupService groupService,
            INotificationDialogController notificationDialogController)
        {
            this.notificationDialogController = notificationDialogController;
            this.dialogService = dialogService;
            this.eventAggregator = eventAggregator;
            this.groupService = groupService;

            items = new ObservableCollection<Group>(groupService.Groups);
        }

        public ObservableCollection<Group> Items
        {
            get => items;
            set => items = value;
        }

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

            DialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add(nameof(AddDialogParameters), addDialogParameters);

            dialogService.Show("AddDialog", dialogParameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    items.Add(model.CreateGroup());
                    groupService.AddGroup(model.CreateGroup());

                    eventAggregator.GetEvent<GroupsCountChangeEvent>().Publish(Items.Count);

                    notificationDialogController.OpenNotificationDialog(Properties.Resources.Notification, Properties.Resources.SuccessAddGroup);
                }

                if (r.Result == ButtonResult.Cancel)
                {

                }
            });
        }

        public void DeleteGroup(Group group)
        {
            var confirmDialogParameters = new ConfirmDialogParameters();
            confirmDialogParameters.Message = Properties.Resources.MessageDeleteGroup;

            DialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add(nameof(ConfirmDialogParameters), confirmDialogParameters);
            dialogService.Show("ConfirmDialog", dialogParameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    items.Remove(group);
                    groupService.DeleteGroup(group);

                    eventAggregator.GetEvent<GroupsCountChangeEvent>().Publish(Items.Count);

                    notificationDialogController.OpenNotificationDialog(Properties.Resources.Notification,
                        Properties.Resources.SuccessDeleteGroup);
                }

                if (r.Result == ButtonResult.Cancel)
                {

                }
            });
        }

        public void CheckGroupsCount()
        {
            eventAggregator.GetEvent<GroupsCountChangeEvent>().Publish(groupService.Groups.Count);
        }
    }
}
