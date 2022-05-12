using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ConfirmDialog
{
    /// <summary>
    /// Параметры для передачи в ConfirgmDialog.
    /// </summary>
    public class ConfirmDialogParameters
    {
        /// <summary>
        /// Текст сообщения.
        /// </summary>
        public string Message { get; set; }
    }
}
