﻿using System;
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

        public void AddGroup()
        {
            AddGroupViewModel model = new AddGroupViewModel();
            AddGroupView view = new AddGroupView() { DataContext = model };

            var confirmDialogParameters = new AddDialogParameters();
            confirmDialogParameters.CloseButtonText = Properties.Resources.Cancel;
            confirmDialogParameters.ConfirmButtonText = Properties.Resources.Add;
            confirmDialogParameters.Header = Properties.Resources.AddingGroup;
            confirmDialogParameters.Title = Properties.Resources.AddingGroup;
            confirmDialogParameters.Content = view;
            confirmDialogParameters.CanCloseWindow = model.CanAddGroup;

            DialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add("confirmDialogParameters", confirmDialogParameters);
          
            dialogService.Show("ConfirmDialog", dialogParameters, r =>
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

        public void CheckGroupsCount()
        {
            eventAggregator.GetEvent<GroupsCountChangeEvent>().Publish(groupService.Groups.Count);
        }

        public ObservableCollection<Group> Items
        {
            get => items;
            set => items = value;
        }
    }
}
