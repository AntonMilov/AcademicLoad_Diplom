using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Infrastructure.NotificationDialog
{
    /// <summary>
    /// ViewModel для окна уведомления.
    /// </summary>
    public class NotificationDialogViewModel : BindableBase, IDialogAware
    {
        private string title;
        private string message;

        /// <summary>
        /// .ctor
        /// </summary>
        public NotificationDialogViewModel()
        {


        }

        /// <summary>
        /// Заголовок окна.
        /// </summary>
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        /// <summary>
        /// Сообщение.
        /// </summary>
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        /// <summary>
        /// Команда закрытия окна.
        /// </summary>
        public DelegateCommand<string> CloseDialogCommand => new DelegateCommand<string>(CloseDialog);

        public event Action<IDialogResult> RequestClose;

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
           
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            var parameter = parameters.GetValue<NotificationDialogParameters>("notificationDialogParameters");

            Title = parameter.Title;
            Message = parameter.Message;
        }

        private void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
                result = ButtonResult.OK;
            
            RaiseRequestClose(new DialogResult(result));
        }
    }
}
