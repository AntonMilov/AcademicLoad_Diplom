using Prism.Commands;
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
        public ConfirmDialogViewModel()
        {

        }

       /// <summary>
       /// Заголовок окна.
       /// </summary>
        public string Title
        {
            get =>  title; 
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
        public string CloseButonText
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

        public bool CanCloseDialog()
        {
            throw new NotImplementedException();
        }

        public void OnDialogClosed()
        {
            throw new NotImplementedException();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
       
            Header = parameters.GetValue<string>("Header");
            Content = parameters.GetValue<object>("Content");

        }
    }
}
