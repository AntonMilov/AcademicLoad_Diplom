using System;
using Infrastructure.AddDialog;
using Infrastructure.ConfirmDialog;
using Infrastructure.DialogControllers.Interfaces;
using Infrastructure.NotificationDialog;
using Prism.Services.Dialogs;

namespace Infrastructure.DialogControllers
{

    /// <inheritdoc/>
    public class DialogController : IDialogController
    {
        private readonly IDialogService dialogService;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="dialogService"><see cref="dialogService"/>.</param>
        public DialogController(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }

        /// <inheritdoc/>
        public void OpenAddDialog(AddDialogParameters addDialogParameters, Action<IDialogResult> callback)
        {
            DialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add(nameof(AddDialogParameters), addDialogParameters);

            dialogService.ShowDialog("AddDialog", dialogParameters, callback);
        }

        /// <inheritdoc/>
        public void OpenConfirmDialog(ConfirmDialogParameters confirmDialogParameters, Action<IDialogResult> callback)
        {
            DialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add(nameof(ConfirmDialogParameters), confirmDialogParameters);

            dialogService.ShowDialog("ConfirmDialog", dialogParameters, callback);
        }

        /// <inheritdoc/>
        public void OpenNotificationDialog(string title, string message)
        {
            var notificationDialogParameters = new NotificationDialogParameters();
            notificationDialogParameters.Message = message;
            notificationDialogParameters.Title = title;

            DialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add("notificationDialogParameters", notificationDialogParameters);

            dialogService.ShowDialog("NotificationDialog", dialogParameters, r =>
            {
                // callback
            });
        }
    }
}
