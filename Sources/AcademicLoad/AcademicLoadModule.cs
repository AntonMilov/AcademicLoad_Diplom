using AcademicLoadModule.Controllers;
using AcademicLoadModule.Controllers.Interfaces;
using AcademicLoadModule.Views;
using AcademicLoadModule.Views.Empty;
using Core;
using Core.Excel;
using Core.Excel.Interfaces;
using Core.Json;
using Core.Json.Interfaces;
using Core.Services;
using Core.Services.Interfaces;
using Infrastructure;
using Infrastructure.DialogControllers;
using Infrastructure.DialogControllers.Interfaces;
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
            regionManager.RegisterViewWithRegion("TeachersRegion", typeof(TeachersEmptyView));
            regionManager.RegisterViewWithRegion("TeachersRegion", typeof(TeachersView));

            regionManager.RegisterViewWithRegion("GroupsRegion", typeof(GroupsEmptyView));
            regionManager.RegisterViewWithRegion("GroupsRegion", typeof(GroupsView));
            
            regionManager.RegisterViewWithRegion("CalculationSheetsRegion", typeof(CalculationSheetsEmptyView));
            regionManager.RegisterViewWithRegion("CalculationSheetsRegion", typeof(CalculationSheetView));

            regionManager.RegisterViewWithRegion("NormsTimeRegion", typeof(NormsTimeView));

            //TODO  TabsView Создается в конце, и проверяет по контроллерам
            regionManager.RegisterViewWithRegion("MainRegion", typeof(TabsView));
        }

        /// <inheritdoc/>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInfrastructure();
            containerRegistry.RegisterCore();

            containerRegistry.RegisterSingleton<ITeacherController, TeacherController>();
            containerRegistry.RegisterSingleton<IGroupController, GroupController>();
            containerRegistry.RegisterSingleton<ICalculationSheetController, CalculationSheetController>();
            containerRegistry.RegisterSingleton<ITeacherLoadDisciplineController, TeacherLoadDisciplineController>();
        }
    }
}