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
    /// Интерфейс для взаимодействия с диалоговым окном Confirm.
    /// </summary>
    public interface IConfirmDialogController
    {
        /// <summary>
        /// Открыть окно Confirm.
        /// </summary>
        void OpenConfirmDialog(ConfirmDialogParameters confirmDialogParameters, System.Action<IDialogResult> callback);
    }
}
