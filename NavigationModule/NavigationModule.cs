using System.Dynamic;
using NavigationModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace NavigationModule
{
    public class NavigationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
 
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<Navigator>();
            
        }

    }
}