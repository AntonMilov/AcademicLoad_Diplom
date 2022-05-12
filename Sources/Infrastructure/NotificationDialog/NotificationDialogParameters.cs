using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.NotificationDialog
{
    /// <summary>
    /// Параметры для передачи в NotificationDialog.
    /// </summary>
    public class NotificationDialogParameters
    {
        /// <summary>
        /// Заголовок окна.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Сообщение.
        /// </summary>
        public string Message { get; set; }
    }
}
