using AcademicLoadModule.Views;
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
            regionManager.RegisterViewWithRegion("GroupsRegion", typeof(GroupsEmptyView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
          
        }
    }
}