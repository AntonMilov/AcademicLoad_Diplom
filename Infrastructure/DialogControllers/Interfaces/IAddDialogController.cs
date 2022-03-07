using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.AddDialog;
using Prism.Services.Dialogs;

namespace Infrastructure.DialogControllers.Interfaces
{
    /// <summary>
    /// Интерфейс для взаимодействия с диалоговым окном Add.
    /// </summary>
    public interface IAddDialogController
    {
        /// <summary>
        /// Открыть окно Add.
        /// </summary>
        void OpenAddDialog(AddDialogParameters addDialogParameters, System.Action<IDialogResult> callback);
    }
}
