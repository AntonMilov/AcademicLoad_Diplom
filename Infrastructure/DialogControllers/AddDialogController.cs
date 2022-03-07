using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.AddDialog;
using Infrastructure.DialogControllers.Interfaces;
using Prism.Services.Dialogs;

namespace Infrastructure.DialogControllers
{

    /// <inheritdoc/>
    public class AddDialogController : IAddDialogController
    {
        private readonly IDialogService dialogService;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="dialogService"><see cref="dialogService"/>.</param>
        public AddDialogController(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }

        /// <inheritdoc/>
        public void OpenAddDialog(AddDialogParameters addDialogParameters, Action<IDialogResult> callback)
        {
            DialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add(nameof(AddDialogParameters), addDialogParameters);

            dialogService.Show("AddDialog", dialogParameters, callback);
        }
    }
}
