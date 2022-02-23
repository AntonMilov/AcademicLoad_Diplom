using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.NotificationDialog.Controller
{
    /// <summary>
    /// Интерфейс для взаимодействия с диалоговым окном Notification.
    /// </summary>
    public interface INotificationDialogController
    {
        void OpenNotificationDialog(string title, string message);
    }
}
