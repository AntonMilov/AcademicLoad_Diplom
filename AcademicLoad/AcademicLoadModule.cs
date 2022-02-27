using AcademicLoadModule.Controllers;
using AcademicLoadModule.Controllers.Interfaces;
using AcademicLoadModule.Views;
using AcademicLoadModule.Views.Empty;
using Core.Excel;
using Core.Excel.Interfaces;
using Core.Services;
using Core.Services.Interfaces;
using Infrastructure.NotificationDialog.Controller;
using Microsoft.Win32;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace AcademicLoadModule
{
    /// <inheritdoc/>
    public class AcademicLoadModule : IModule
    {
        /// <inheritdoc/>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("MainRegion", typeof(TabsView));

            regionManager.RegisterViewWithRegion("TeachersRegion", typeof(TeachersEmptyView));
            regionManager.RegisterViewWithRegion("TeachersRegion", typeof(TeachersView));

            regionManager.RegisterViewWithRegion("GroupsRegion", typeof(GroupsEmptyView));
            regionManager.RegisterViewWithRegion("GroupsRegion", typeof(GroupsView));

            regionManager.RegisterViewWithRegion("CalculationSheetsRegion", typeof(CalculationSheetsEmpty));
        }

        /// <inheritdoc/>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<INotificationDialogController, NotificationDialogController>();
            containerRegistry.Register<OpenFileDialog>();
            containerRegistry.Register<IExcelExporter,ExcelExporter>();


            containerRegistry.RegisterSingleton<ITeacherController, TeacherController>();
            containerRegistry.RegisterSingleton<ITeacherService, TeacherService>();

            containerRegistry.RegisterSingleton<IGroupController, GroupController>();


            containerRegistry.RegisterSingleton<ICalculationSheetController, CalculationSheetController>();
            containerRegistry.RegisterSingleton<ICalculationSheetService, CalculationSheetService>();
        }
    }
}