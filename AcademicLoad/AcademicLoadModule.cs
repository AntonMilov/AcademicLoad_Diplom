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
            regionManager.RegisterViewWithRegion("TeachersList", typeof(TeachersView));
            regionManager.RegisterViewWithRegion("test1", typeof(TeachersEmptyView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
          
        }
    }
}