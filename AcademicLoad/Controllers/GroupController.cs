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
        private ObservableCollection<Group> items;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="dialogService"></param>
        /// <param name="eventAggregator"></param>
        /// <param name="teacherService"></param>
        /// <param name="notificationDialogController"></param>
        public GroupController(IDialogService dialogService, IEventAggregator eventAggregator, ITeacherService teacherService, INotificationDialogController notificationDialogController)
        {
            this.notificationDialogController = notificationDialogController;
            this.dialogService = dialogService;
            this.eventAggregator = eventAggregator;

            items = new ObservableCollection<Group>();
        }

        public void AddGroup()
        {
            AddGroupViewModel model = new AddGroupViewModel();
            AddGroupView view = new AddGroupView() { DataContext = model };

            var confirmDialogParameters = new ConfirmDialogParameters();
            confirmDialogParameters.CloseButtonText = Properties.Resources.Cancel;
            confirmDialogParameters.ConfirmButtonText = Properties.Resources.Add;
            confirmDialogParameters.Header = Properties.Resources.AddingGroup;
            confirmDialogParameters.Title = Properties.Resources.AddingGroup;
            confirmDialogParameters.Content = view;
            confirmDialogParameters.CanCloseWindow = model.CanAddGroup;

            DialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add("confirmDialogParameters", confirmDialogParameters);
            //using the dialog service as-is
            dialogService.Show("ConfirmDialog", dialogParameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    items.Add(model.CreateGroup());
                    eventAggregator.GetEvent<GroupsCountChangeEvent>().Publish(Items.Count);
                    notificationDialogController.OpenNotificationDialog(Properties.Resources.Notification, Properties.Resources.SuccessAddGroup);
                }
                if (r.Result == ButtonResult.Cancel)
                {

                }
            });
        }

        public ObservableCollection<Group> Items
        {
            get => items;
            set => items = value;
        }
    }
}
