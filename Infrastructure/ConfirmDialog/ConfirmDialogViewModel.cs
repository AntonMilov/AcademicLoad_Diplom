﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Infrastructure.ConfirmDialog
{
    public class ConfirmDialogViewModel : BindableBase, IDialogAware
    {
        private object content;
        private string title;
        private string header;
        private string сloseButonText;
        private string сonfirmButtonText;
        /// <summary>
        /// .ctor
        /// </summary>
        public ConfirmDialogViewModel()
        {

        }

        public DelegateCommand<string> CloseDialogCommand => new DelegateCommand<string>(CloseDialog);



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

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            var parameter = parameters.GetValue<ConfirmDialogParameters>("confirmDialogParameters");

            Header = parameter.Header;
            Title = parameter.Title;
            CloseButtonText = parameter.CloseButtonText;
            ConfirmButtonText = parameter.ConfirmButtonText;
            Content = parameter.Content;
        }

        private void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
                result = ButtonResult.OK;
            else if (parameter?.ToLower() == "false")
                result = ButtonResult.Cancel;

            RaiseRequestClose(new DialogResult(result));
        }
    }
}
