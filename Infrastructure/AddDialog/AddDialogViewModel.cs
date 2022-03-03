using System;
using Infrastructure.NotificationDialog.Controller;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Infrastructure.AddDialog
{
    /// <summary>
    /// ViewModel для окна потверждения.
    /// </summary>
    public class AddDialogViewModel : BindableBase, IDialogAware
    {
        private readonly INotificationDialogController notificationDialogController;
        private object content;
        private string title;
        private string header;
        private string сloseButonText;
        private string сonfirmButtonText;

        /// <summary>
        /// .ctor
        /// </summary>
        public AddDialogViewModel(INotificationDialogController notificationDialogController)
        {
            this.notificationDialogController = notificationDialogController;
        }

        /// <summary>
        /// Команда закрытия окна.
        /// </summary>
        public DelegateCommand<string> CloseDialogCommand => new DelegateCommand<string>(CloseDialog);

        /// <summary>
        /// Делегат на функцию для опрелеления возможности закрытия окна.
        /// </summary>
        public Func<bool> CanCloseWindow { get; set; }

        /// <summary>
        /// Заголовок окна.
        /// </summary>
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        /// <summary>
        /// Контент.
        /// </summary>
        public object Content
        {
            get => content;
            set => SetProperty(ref content, value);
        }

        /// <summary>
        /// Текст для кнопки закрытия.
        /// </summary>
        public string CloseButtonText
        {
            get => сloseButonText;
            set => SetProperty(ref сloseButonText, value);
        }

        /// <summary>
        /// Текст для кнопки потверждения.
        /// </summary>
        public string ConfirmButtonText
        {
            get => сonfirmButtonText;
            set => SetProperty(ref сonfirmButtonText, value);
        }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Header
        {
            get => header;
            set => SetProperty(ref header, value);
        }

        public event Action<IDialogResult> RequestClose;

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        /// <summary>
        /// Может ли окно закрыться.
        /// </summary>
        /// <returns></returns>
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            var parameter = parameters.GetValue<AddDialogParameters>("confirmDialogParameters");

            Header = parameter.Header;
            Title = parameter.Title;
            CloseButtonText = parameter.CloseButtonText;
            ConfirmButtonText = parameter.ConfirmButtonText;
            Content = parameter.Content;
            CanCloseWindow = parameter.CanCloseWindow;
        }

        private void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
            {
                if (!CanCloseWindow())
                {
                    notificationDialogController.OpenNotificationDialog(Properties.Resources.Error, Properties.Resources.ErrorConfirm);
                }
                else
                {
                    result = ButtonResult.OK;
                }

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
