using Infrastructure.DialogControllers.Interfaces;
using Infrastructure.NotificationDialog;
using Prism.Services.Dialogs;

namespace Infrastructure.DialogControllers
{
    /// <summary>
    /// <see cref="INotificationDialogController"/>
    /// </summary>
    public class NotificationDialogController : INotificationDialogController
    {
        private IDialogService dialogService;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="dialogService"></param>
        public NotificationDialogController(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }

        /// <inheritdoc/>
        public void OpenNotificationDialog(string title, string message)
        {
            var notificationDialogParameters = new NotificationDialogParameters();
            notificationDialogParameters.Message = message;
            notificationDialogParameters.Title = title;

            DialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add("notificationDialogParameters", notificationDialogParameters);

            dialogService.Show("NotificationDialog", dialogParameters, r =>
            {
             // callback
            });
        }
    }
}
