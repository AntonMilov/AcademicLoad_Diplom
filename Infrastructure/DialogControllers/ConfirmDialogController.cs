using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.ConfirmDialog;
using Infrastructure.DialogControllers.Interfaces;
using Prism.Services.Dialogs;

namespace Infrastructure.DialogControllers
{
    /// <inheritdoc/>
    public class ConfirmDialogController : IConfirmDialogController
    {
        private readonly IDialogService dialogService;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="dialogService"></param>
        public ConfirmDialogController(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }

        /// <inheritdoc/>
        public void OpenConfirmDialog(ConfirmDialogParameters confirmDialogParameters, Action<IDialogResult> callback)
        {
            DialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add(nameof(ConfirmDialogParameters), confirmDialogParameters);

            dialogService.Show("ConfirmDialog", dialogParameters, callback);
        }
    }
}
