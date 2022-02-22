using AcademicLoadModule.Controllers;
using AcademicLoadModule.Controllers.Interfaces;
using AcademicLoadModule.Views;
using Core.Services;
using Core.Services.Interfaces;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace AcademicLoadModule
{
    public class AcademicLoadModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("MainRegion", typeof(TabsView));
            regionManager.RegisterViewWithRegion("TeachersRegion", typeof(TeachersEmptyView));
            regionManager.RegisterViewWithRegion("TeachersRegion", typeof(TeachersView));
            regionManager.RegisterViewWithRegion("GroupsRegion", typeof(GroupsEmptyView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ITeacherController, TeacherController>();
            containerRegistry.RegisterSingleton<ITeacherService, TeacherService>();
        }
    }
}