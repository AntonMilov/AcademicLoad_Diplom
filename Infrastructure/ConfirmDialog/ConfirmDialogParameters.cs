﻿

namespace Infrastructure.ConfirmDialog
{
    /// <summary>
    /// Параметры для передачи в ConfirgmDialog.
    /// </summary>
    public class ConfirmDialogParameters
    {
        /// <summary>
        /// Заголовок окна.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Текст для кнопки закрытия.
        /// </summary>
        public string CloseButonText { get; set; }


        /// <summary>
        /// Текст для кнопки потверждения.
        /// </summary>
        public string ConfirmButtonText { get; set; }


        /// <summary>
        /// Контент.
        /// </summary>
        public object Content { get; set; }
    }
}