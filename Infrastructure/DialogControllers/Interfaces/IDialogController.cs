using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.AddDialog;
using Infrastructure.ConfirmDialog;
using Prism.Services.Dialogs;

namespace Infrastructure.DialogControllers.Interfaces
{
    /// <summary>
    /// Интерфейс для взаимодействия с диалоговыми окнами
    /// </summary>
    public interface IDialogController
    {
        /// <summary>
        /// Открыть окно Add.
        /// </summary>
        void OpenAddDialog(AddDialogParameters addDialogParameters, System.Action<IDialogResult> callback);

        /// <summary>
        /// Открыть окно Notification.
        /// </summary>
        void OpenNotificationDialog(string title, string message);

        /// <summary>
        /// Открыть окно Confirm.
        /// </summary>
        void OpenConfirmDialog(ConfirmDialogParameters confirmDialogParameters, System.Action<IDialogResult> callback);
    }
}
