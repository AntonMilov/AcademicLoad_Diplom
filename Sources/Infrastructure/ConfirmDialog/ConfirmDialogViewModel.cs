using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Infrastructure.ConfirmDialog
{
    /// <summary>
    /// ViewModel для окна подтверждения.
    /// </summary>
    public class ConfirmDialogViewModel : BindableBase, IDialogAware
    {
        private string message;

        /// <summary>
        /// Заголовок окна.
        /// </summary>
        public string Title => "Потдверждение";

        /// <summary>
        /// Сообщение.
        /// </summary>
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        public event Action<IDialogResult> RequestClose;

        /// <summary>
        /// Команда закрытия окна.
        /// </summary>
        public DelegateCommand<string> CloseDialogCommand => new DelegateCommand<string>(CloseDialog);

        public void OnDialogClosed()
        {

        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            var parameter = parameters.GetValue<ConfirmDialogParameters>(nameof(ConfirmDialogParameters));
            Message = parameter.Message;
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        private void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
            {
                result = ButtonResult.OK;
            }
            else if (parameter?.ToLower() == "false")
            {
                result = ButtonResult.Cancel;
            }
            if (result != ButtonResult.None)
            {
                RaiseRequestClose(new DialogResult(result));
            }
        }
    }
}
