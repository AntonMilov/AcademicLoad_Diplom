using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.AddDialog;
using Infrastructure.ConfirmDialog;
using Infrastructure.DialogControllers;
using Infrastructure.DialogControllers.Interfaces;
using Microsoft.Win32;
using Prism.Ioc;

namespace Infrastructure
{
    /// <summary>
    /// Класс расширений для регистрации Infrastructure.
    /// </summary>
    public static class InfrastructureContainerExtensions
    {
        /// <summary>
        /// Расширение IContainerRegistry для регистрации для IContainerRegistry.
        /// </summary>
        /// <param name="containerRegistry"></param>
        public static void RegisterInfrastructure(this IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDialogController, DialogController>();
            containerRegistry.Register<OpenFileDialog>();

            containerRegistry.RegisterDialog<AddDialogView, AddDialogViewModel>("AddDialog");
            containerRegistry.RegisterDialog<ConfirmDialogView, ConfirmDialogViewModel>("ConfirmDialog");
            containerRegistry.RegisterDialog<Infrastructure.NotificationDialog.NotificationDialogView, Infrastructure.NotificationDialog.NotificationDialogViewModel>("NotificationDialog");
        }
    }
}
