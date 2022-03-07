namespace Infrastructure.DialogControllers.Interfaces
{
    /// <summary>
    /// Интерфейс для взаимодействия с диалоговым окном Notification.
    /// </summary>
    public interface INotificationDialogController
    {
        /// <summary>
        /// Открыть окно Notification.
        /// </summary>
        void OpenNotificationDialog(string title, string message);
    }
}
