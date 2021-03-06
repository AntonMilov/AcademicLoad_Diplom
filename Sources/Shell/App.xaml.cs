using System.Windows;
using Infrastructure.AddDialog;
using Infrastructure.ConfirmDialog;
using NavigationModule;
using Prism.Ioc;
using Prism.Modularity;
using Shell.Views;

namespace Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AcademicLoadModule.AcademicLoadModule>();
            moduleCatalog.AddModule<NavigationModule.NavigationModule>();
        }
    }
}
